using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Model;

namespace WebService.DAL
{
    public class PollAPIDbContext: DbContext
    {
        public PollAPIDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<PollAPIReponse> PollAPIReponses { get; set; }
    }
}
