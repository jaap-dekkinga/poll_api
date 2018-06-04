using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebService.Model;

namespace WebService.ViewModel
{
    public class PollAPIRequestViewModel
    {
        [Required]
        public string Response { get;  set; }
        [Required]
        public DateTimeOffset ResponseTime { get;  set; }
        public string Name { get; set; }
    }


}
