using TFLBank.models;

namespace TFLBank.FileManager
{
    public interface IOperationsRepository
    {
        bool SaveOpeations(List<Operation> operations);
        List<Operation> GetAllOperations();
    }
}