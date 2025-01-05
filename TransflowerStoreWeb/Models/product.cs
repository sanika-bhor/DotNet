using System.Runtime.CompilerServices;

namespace Catelog
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description{get; set;}
        public int UnitPrice{get;set;}
        public int Quantity{get;set;}

        public Product(int id,string name,string des, int price,int stock )
        {
            this.Id=id;
            this.ProductName=name;
            this.Description=des;
            this.UnitPrice=price;
            this.Quantity=stock;
        }
    }
}