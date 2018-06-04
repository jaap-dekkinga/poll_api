using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebService.Model;
using WebService.ViewModel;

namespace WebService.Extensions
{
    public static class PollAPIResponseExtensions
    {
        static Func<PollAPIRequestViewModel ,PollAPIReponse> expPollAPIRequestViewModelToPollAPIResponse = (pollAPIRequestViewModel) => new PollAPIReponse
        {
            Response = pollAPIRequestViewModel.Response,
            ResponseTime = pollAPIRequestViewModel.ResponseTime,
            Name = pollAPIRequestViewModel.Name
        };
        public static PollAPIReponse ToPollAPIResponse(this PollAPIRequestViewModel pollAPIRequestViewModel)
        {
            return expPollAPIRequestViewModelToPollAPIResponse(pollAPIRequestViewModel);
        }
    }
}
