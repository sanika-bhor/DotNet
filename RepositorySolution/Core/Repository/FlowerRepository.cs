using core.Model.Flower;
using Core.Repository.Interface;
namespace Core.Repository;


public class FlowerRepository:IFlowerRepository
{
    public List<Flower> GetAllFlowers()
    {
        List<Flower> flowers=new List<Flower>();
        flowers.Add(new Flower
        {
            FlowerId=1,
            FlowerName="Rose",
            Discription="valentine flower",
            UnitPrice=21.1,
            Quantity=10
        });

        flowers.Add(new Flower
        {
            FlowerId = 2,
            FlowerName = "Lotus",
            Discription = "beautiful flower",
            UnitPrice = 21.1,
            Quantity = 10
        });

        flowers.Add(new Flower
        {
            FlowerId = 1,
            FlowerName = "gerberra",
            Discription = "Merrage flower",
            UnitPrice = 21.1,
            Quantity = 10
        });

        flowers.Add(new Flower
        {
            FlowerId = 1,
            FlowerName = "Rose",
            Discription = "valentine flower",
            UnitPrice = 21.1,
            Quantity = 10
        });

        return flowers;
    }
}