using Model.Flower;

namespace Repository.Interface;

public interface IFlowerRepository
{
    public List<Flower> getAllFlowers();
    public Flower getFlowerById(int id);
}