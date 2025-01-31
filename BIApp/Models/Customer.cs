namespace BIApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public Customer(int id, string name,string loc,int age)
        {
            this.CustomerId=id;
            this.CustomerName=name;
            this.Address=loc;
            this.Age=age;
        }
    }
}