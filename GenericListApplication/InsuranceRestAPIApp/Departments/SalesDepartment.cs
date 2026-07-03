using  MaxNewYorkInsurance.Models;
namespace MaxNewYorkInsurance.Departments;


public class SalesDepartment
{
    public void OnPolicyPurchased(Policy policy)
    {
        Console.WriteLine($"Policy Sold  {policy}" );
    } 

        
}