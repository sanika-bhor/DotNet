namespace MaxNewYorkInsurance.Managers;

using MaxNewYorkInsurance.Agents;
using MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Repositories;


public class InsurancePolicyManager
{
    //evnets
    public event RenewalAgent? policyRenewed;
    public event AccountsAgent? policyPurchased;
    public event ClaimsAgent? claimRegistered;




    public event PremiumAgent? premiumPaid;

    public void RegisterClaim(Claim claim)
    {
        claimRegistered?.Invoke(claim);
    }

    public bool RenewPolicy(string policyNumber)
    {
        PolicyRepository policyRepository = new PolicyRepository();
        List<Policy> policies = policyRepository.GetAllPolicies();

        bool status = false;

        foreach (Policy policy in policies)
        {
            if (policy.PolicyNumber == policyNumber)
            {
                policy.IsRenewed = true;
                status = true;
                break;
            }
        }

        if (status)
        {
            policyRepository.SaveAllPolicies(policies);
            policyRenewed?.Invoke();
        }

        return status;
    }

    public void PurchasePolicy(Policy policy)
    {
        policyPurchased?.Invoke(policy);
    }

   public void PayPremium(Premium premium)
    {
        premiumPaid?.Invoke(premium);
    }
   
}