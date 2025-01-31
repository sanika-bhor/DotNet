namespace BIApp.Models
{
    public class Sales
    {
        public List<Product> products=new List<Product>();
        public List<Customer> customers=new List<Customer>();
    }


    public class SalesRevenueAcessLayer:Sales
    {
        public List<Customer> FillCustomer()
       {
            customers.Add(new Customer(1, "sanika", "manchar", 20));
            customers.Add(new Customer(2, "sumit", "awsari", 20));
            customers.Add(new Customer(3, "ajinkya", "pune", 20));
            return customers;
        }
        public List<Product> FillProduct()
        {
            products.Add(new Product(1,"laptop","educational use",25600,2));
            products.Add(new Product(2,"mobile","entertainment use",15000,36));
            products.Add(new Product(1,"Tab","professsional use",19500,2));
            return products;
        }
    }
}


