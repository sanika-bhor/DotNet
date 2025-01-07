using CRM;
using DAL;

namespace BLL;

public class CustomerBLLManager
{
    public static List<Customer> getAllProducts()
    {
        List<Customer> allCustomers = (List<Customer>)CustomerDALManager.getAllProductFromDB();
        Console.WriteLine("getting product");

        return allCustomers;

    }

    public static Customer getProductByID(int id)
    {
        Customer customer = CustomerDALManager.getProductById(id);
        return customer;
    }
}