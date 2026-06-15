using MaxNewYorkInsurance.Agents;
using MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Repositories;

namespace MaxNewYorkInsurance.Departments;

public class AccountsDepartment
{

    public void OnPurchasePolicy(Policy policy)
    {
        PolicyRepository repo=new PolicyRepository();
        List<Policy> policies = repo.GetAllPolicies();
        policies.Add(policy);
        repo.SaveAllPolicies(policies);
        Console.WriteLine("Payment recorded successfully.");
    }

    public void onPayPremium(Premium premium)
    {
        PremiumRepository repository = new PremiumRepository();
        List<Premium> premiums = repository.GetAllPremium();
        premiums.Add(premium);
        repository.SaveAllPremium(premiums);
      
        Console.WriteLine("Premium is paid Successfully");
    }



}