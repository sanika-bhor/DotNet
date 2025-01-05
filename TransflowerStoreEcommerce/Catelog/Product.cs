namespace Catelog;

public class Product
{
    public int ProductId{get; set;}
    public string ProductName{get;set;}
    public string Description{get; set;}
    public double UnitPrice{get; set;}
    public int Quantity{get;set;}
    public string Image{get;set;}

    public Product(){
        this.ProductId=1;
        this.ProductName="Rose";
        this.Description="This is a valentine flower";
        this.UnitPrice=10.00;
        this.Quantity=10;
        this.Image="/images/flowers/rose.jpg";
    }
    public Product(int productId, string productName, string description, double unitPrice, int quantity,string image)
    {
        this.ProductId=productId;
        this.ProductName=productName;
        this.Description=description;
        this.UnitPrice=unitPrice;
        this.Quantity=quantity;
        this.Image=image;
    }

}
