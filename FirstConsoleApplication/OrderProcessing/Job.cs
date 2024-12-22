using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class Job
    {
        public int Id { get; set; }
        public StringInfo Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool Status { get; set; }
    }
}
