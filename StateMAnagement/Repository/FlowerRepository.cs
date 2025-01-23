using Model.Flower;

namespace Repository.FlowerRepository;

public interface FlowerRepository
{
    public List<Flower> getAllFlowers()
    {
        List<Flower> allFlower=new List<Flower>()
        {
            new Flower
            {
                FlowerId=1,
                FlowerName="rose",
                Discription="valentine flower",
                UnitPrice=15,
                Quantity=5
            },

            new Flower
            {
                FlowerId=2,
                FlowerName="Gerberra",
                Discription="Merrage flower",
                UnitPrice=7,
                Quantity=445
            },

            new Flower
            {
                FlowerId=3,
                FlowerName="Mogara",
                Discription="smelly flower",
                UnitPrice=2,
                Quantity=5150
            }
        };

        return allFlower;
    }
    public Flower getFlowerById(int id);
}