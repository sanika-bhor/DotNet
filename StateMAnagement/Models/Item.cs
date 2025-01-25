namespace Model.Cart;

[Serializable]
public class Item
{
    public int FlowerId { get; set; }
    public string FlowerName { get; set; }
    public int Quantity { get; set; }
}