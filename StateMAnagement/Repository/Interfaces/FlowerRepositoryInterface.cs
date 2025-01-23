using Model.Flower;

namespace Repository.Interface;

public interface FlowerRepositoryInterface
{
    public List<Flower> getAllFlowers();
    public Flower getFlowerById(int id);
}