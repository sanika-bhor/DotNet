using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace - logical collection of .net type like class
namespace CRM
{
    public class Customer
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public string Location { get; set; }
    }
}