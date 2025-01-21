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
    public List<Flower> GetAllFlowers()=> _flowerRepo.GetAllFlowers();

    // public List<Flower> GetAllFlowers()
    // {
    //     return GetAllFlowers();
    // }
}