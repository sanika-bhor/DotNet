using System.Reflection.Metadata.Ecma335;
using core.Model.Flower;

namespace Core.Repository.Interface;
public interface IFlowerRepository
{
    public List<Flower> GetAllFlowers();
}

