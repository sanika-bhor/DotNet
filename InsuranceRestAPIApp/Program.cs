using MaxNewYorkInsurance.Managers;
using MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Services;
using MaxNewYorkInsurance.Departments;
using MaxNewYorkInsurance.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapGet("/api/policies", () =>
{
        PolicyRepository policyRepository=new PolicyRepository();
        return policyRepository.GetAllPolicies();
});

app.MapPost("/api/policies/purchase", (Policy policy) =>
{
  
        InsurancePolicyManager insruanceManager=new InsurancePolicyManager();
        AccountsDepartment accounts=new AccountsDepartment();
        SalesDepartment sales=new SalesDepartment();  
        insruanceManager.policyPurchased+=accounts.OnPurchasePolicy;
        // insruanceManager.policyPurchased+=sales.OnPolicyPurchased;
        insruanceManager.PurchasePolicy(policy);
         return " Policy Purchased Successfully";
});

app.MapPost("/api/policies/paypremium", (Premium premium) =>
{
  
        InsurancePolicyManager insruanceManager=new InsurancePolicyManager();
        AccountsDepartment accounts=new AccountsDepartment();
        insruanceManager.premiumPaid+=accounts.onPayPremium;
       
        insruanceManager.PayPremium(premium);
        return " Preimum paid succefully";
  
});

app.MapPost("/api/policies/registerclaim", (Claim claim) =>
{
  
        InsurancePolicyManager insruanceManager=new InsurancePolicyManager();
        ClaimDepartment claims=new ClaimDepartment();

        insruanceManager.claimRegistered+= claims.OnClaimRegistered;
        insruanceManager.RegisterClaim(claim);
        return "Claim is Register";

});
app.MapPost("/api/policies/renew", (Policy policy) =>
{
  
        InsurancePolicyManager insruanceManager=new InsurancePolicyManager();
        AccountsDepartment accounts=new AccountsDepartment();
        SalesDepartment sales=new SalesDepartment();
        ClaimDepartment claims=new ClaimDepartment();
        RenewalDepartment renewals=new RenewalDepartment();

        EmailNotificationService emailSvc=new EmailNotificationService();

        insruanceManager.policyRenewed += renewals.OnPolicyRenewed;
          bool status = insruanceManager.RenewPolicy(policy.PolicyNumber);
        if(status)
        {
                return Results.Ok("Policy Renewed Successfully");
        }

        return Results.NotFound("Policy Not Found");

});
 

app.Run();
