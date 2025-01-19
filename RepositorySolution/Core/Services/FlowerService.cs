using core.Model.Flower;
using Core.Repository.Interface;
using Core.Services.Interface;

namespace Core.Services;
public class FlowerService:IFlowerService
{
    private readonly IFlowerRepository _flowerRepo;

    public FlowerService(IFlowerRepository flowerRepository)
    {
        this._flowerRepo=flowerRepository;
    }
    List<Flower> GetAllFlowers()=> _flowerRepo.GetAllFlowers();

    List<Flower> IFlowerRepository.GetAllFlowers()
    {
        return GetAllFlowers();
    }
}