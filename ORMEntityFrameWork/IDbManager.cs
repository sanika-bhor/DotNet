namespace ORMEntityFramework
{
    public interface IDbManager
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert();
        void Update();
        void Delete();
    }
}