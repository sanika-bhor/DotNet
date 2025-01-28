namespace ORMEntityFramework
{
    public interface IDbManager
    {
        List<Product> GetAll();
        Product GetById();
        void Insert();
        void Update();
        void Delete();
    }
}