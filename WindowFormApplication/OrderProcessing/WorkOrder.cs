using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    public class WorkOrder : Order
    {
        public string Vendor { get; set; }
        public string Discription{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int priority { get; set; }
        public bool status { get; set; }
        List<Job> jobs=new List<Job>();
    }
}
