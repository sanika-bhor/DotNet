namespace BIApp.Models
{
    public class Product
    {
        public int ProductId{get;set;}
        public string ProductTitle{get;set;}
        public string Discription{get;set;}
        public double UnitPrice{get;set;}
        public int Quantity{get;set;}

        public Product(int id, string title, string dis, double price, int quantity)
        {
            this.ProductId=id;
            this.ProductTitle=title;
            this.Discription=dis;
            this.UnitPrice=price;
            this.Quantity=quantity;
        }
    }
}