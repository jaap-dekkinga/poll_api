using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Model
{
    public class PollAPIReponse
    {
        public int Id { get; set; }
        public DateTimeOffset ResponseTime { get; set; }
        public string Response { get; set; }
        public string Name { get;  set; }
    }
}
