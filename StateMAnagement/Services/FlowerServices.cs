using Model.Flower;
using Repository.Interface;
using Service.Interface;

namespace Service.FlowerService;

public class FlowerServices : IFlowerService
{
    private readonly IFlowerRepository _repository;

    public FlowerServices(IFlowerRepository repository)
    {
        _repository=repository;
    }

    public  List<Flower> getAllFlowers()
    {
      List<Flower> flowers=  _repository.getAllFlowers();
        return flowers;
    }

    public Flower getFlowerById(int id)
    {
       Flower flower=_repository.getFlowerById(id);
       return flower;
    }
}