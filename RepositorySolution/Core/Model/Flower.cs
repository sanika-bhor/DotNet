namespace core.Model.Flower;

public class Flower
{
    public int FlowerId{get;set;}
    public string FlowerName{get;set;}
    public string Discription{get;set;}
    public double UnitPrice{get;set;}
    public int Quantity{get;set;}
    
    public Flower()
    {}


    public Flower(int id, string name, string discription,double unitPrice, int quantity)
    {
        this.FlowerId=id;
        this.FlowerName=name;
        this.Discription=discription;
        this.UnitPrice=unitPrice;
        this.Quantity=quantity;
    }
}