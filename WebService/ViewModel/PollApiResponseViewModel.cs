using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModel
{
    public class PollAPIResponseViewModel
    {
        public int NumberOfNo { get; set; }
        public int NumberOfYes { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Name { get; set; }
    }
}
