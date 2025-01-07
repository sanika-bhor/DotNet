using CRM;
using DAL;

namespace BLL;

public class CustomerBLLManager
{
    public static List<Customer> getAllCustomers()
    {
        List<Customer> allCustomers = (List<Customer>)CustomerDALManager.getAllCustomerFromDB();
        Console.WriteLine("getting product");

        return allCustomers;

    }

    public static Customer getCustomerByID(int id)
    {
        Customer customer = CustomerDALManager.getCustomerById(id);
        return customer;
    }
}