namespace ShoppingCart;
using Catelog;

 public class Item
 {
     public int Quantity{get;set;}
     public int CustomerId{get;set;}
     public Product product{get;set;}

     public Item(Product product, int quntity,int customerid)
     {
        this.CustomerId=customerid;
         this.product = product;
         this.Quantity = quntity;
     }

 }