namespace ORMEntityFramework
{
    public interface IDbManager
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Insert(Product product);
        bool Update(Product product);
        void Delete();
    }
}