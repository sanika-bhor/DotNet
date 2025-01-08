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

    public static bool insertCustomer(Customer c)
    {
        return CustomerDALManager.insertCustomer(c);
    }

    public static bool UpdateCustomer(Customer c)
    {
        return CustomerDALManager.UpdateCustomer(c);
    }

    public static bool deleteCustomerById(int id)
    {
        bool status = CustomerDALManager.deleteCustomerById(id);
        return status;
    }
}