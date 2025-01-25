using Model.Flower;

namespace Repository.Interface;

public interface IFlowerRepository
{
    List<Flower> getAllFlowers();
     Flower getFlowerById(int id);

}