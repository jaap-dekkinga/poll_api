using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Parsing.Structure;
using WebService.DAL;
using WebService.Extensions;
using WebService.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class PollAPIController : Controller
    {
        private readonly PollAPIDbContext _pollAPIDbContext;

        public PollAPIController(PollAPIDbContext pollAPIDbContext)
        {
            _pollAPIDbContext = pollAPIDbContext;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {            
                var timestampGroups =  await _pollAPIDbContext.PollAPIReponses
                                                              .Where(pAPIResp => pAPIResp.Name == name)
                                                              .GroupBy(pollApiResp => new
            {
                pollApiResp.ResponseTime.Year,
                pollApiResp.ResponseTime.Month,
                pollApiResp.ResponseTime.Day,
                pollApiResp.ResponseTime.Hour,
                pollApiResp.ResponseTime.Minute
            }).Select(grp => new {
                NumberOfYes = grp.Count(pAPIResp => pAPIResp.Response.ToLower() == "yes"),
                NumberOfNo = grp.Count(pAPIResp => pAPIResp.Response.ToLower() == "no"),
                TimeStamp = new DateTimeOffset(grp.Key.Year, grp.Key.Month, grp.Key.Day, grp.Key.Hour, grp.Key.Minute, 0, TimeSpan.Zero),
                grp.FirstOrDefault().Name
            }).ToListAsync();
            
            return Ok(timestampGroups);
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PollAPIRequestViewModel pollApiRequestViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pollAPIResponse = pollApiRequestViewModel.ToPollAPIResponse();

            _pollAPIDbContext.Entry(pollAPIResponse).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _pollAPIDbContext.SaveChangesAsync();

            return Ok(await Get(pollApiRequestViewModel.Name));
        }
    }
}
