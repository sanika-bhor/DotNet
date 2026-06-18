using MaxNewYorkInsurance.Managers;
using MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Services;
using MaxNewYorkInsurance.Departments;
using MaxNewYorkInsurance.Agents;
using MaxNewYorkInsurance.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

// Purchase a new policy
app.MapPost("/api/policies/purchase", (Policy policy) =>
{
    SalesManager salesManager = new SalesManager();
    SalesDepartment sales = new SalesDepartment();
    AccountsDepartment accounts = new AccountsDepartment();
    salesManager.policyPurchased += sales.OnPolicyPurchased;
    salesManager.policyPurchased += accounts.OnPolicyPurchased;
    salesManager.PurchasePolicy(policy);
    return " Policy Purchased Successfully";
});

// Renew policy
app.MapPost("/api/policies/renew/{policyno}", (string policyno) =>
{

    RenewalManager renewalManager = new RenewalManager();
    RenewalDepartment renewals = new RenewalDepartment();

    renewalManager.policyRenewed += renewals.OnRenewPolicy;
    // insruanceManager.claimRegistered+=claims.OnClaimRegistered;
    renewalManager.RenewPolicy(policyno);
    return Results.Ok("Policy Renewed Successfully");
});

// Pay premium
app.MapPost("/api/policies/paypremium", (Premium premium) =>
{
    PremiumManager premiumManager = new PremiumManager();
    AccountsDepartment accounts = new AccountsDepartment();
    premiumManager.premiumPaid += accounts.OnPremiumPaid;
    premiumManager.premiumPaid += accounts.OnPaymentReceiptGenerated;

    premiumManager.PayPremium(premium);
    return " Preimum paid succefully";

});


// Register claim
app.MapPost("/api/policies/registerclaim", (Claim claim) =>
{

    ClaimsManager claimsManager = new ClaimsManager();
    AccountsDepartment accounts = new AccountsDepartment();
    SalesDepartment sales = new SalesDepartment();
    ClaimDepartment claims = new ClaimDepartment();
    RenewalDepartment renewals = new RenewalDepartment();
    EmailNotificationService emailSvc = new EmailNotificationService();
    // claimsManager.policyPurchased+=sales.OnPolicyPurchased;
    claimsManager.claimRegistered += claims.OnClaimRegistered;
    claimsManager.RegisterClaim(claim);
    return "Claim Register notification send to you!! plz check";

});

// Approve claim
app.MapPost("/api/claims/approve/", (Claim claim) =>
{
    ClaimsManager claimsManager = new ClaimsManager();
    ClaimDepartment claims = new ClaimDepartment();
    AccountsDepartment accounts=new AccountsDepartment();

    claimsManager.claimApproved += claims.OnClaimApproved;
    claimsManager.claimApproved += accounts.OnClaimApproved;

    claimsManager.ApproveClaim(claim);

    return Results.Ok("Claim provide for approval plz check.");
});


// Settle claim
app.MapPost("/api/claims/settle", (Claim claim) =>
{
    ClaimsManager claimManager = new ClaimsManager();

    ClaimDepartment claims = new ClaimDepartment();
    AccountsDepartment accounts = new AccountsDepartment();

    claimManager.claimSettled += claims.OnClaimSettled;
    // claimManager.claimSettled += accounts.OnClaimSettled;

    claimManager.SettleClaim(claim);

    return Results.Ok("Claim settled successfully.");
});

//Reject claim
app.MapPost("/api/claims/reject", (Claim claim) =>
{
    ClaimsManager claimManager = new ClaimsManager();

    ClaimDepartment claims = new ClaimDepartment();

    claimManager.claimRejected += claims.OnClaimRejected;

    claimManager.RejectClaim(claim);

    return Results.Ok("Claim rejected successfully.");
});

// Get all policies
app.MapGet("/api/policies", () =>
{
    PolicyRepository repo = new PolicyRepository();
    return repo.GetAllPolicies();
});


// // Register a customer
// app.MapPost("/api/customers/register", (Customer customer) =>
// {
//     CustomerManager customerManager = new CustomerManager();

//     CustomerServiceDepartment customerService =
//         new CustomerServiceDepartment();

//     customerManager.customerRegistered += customerService.OnCustomerRegistered;

//     customerManager.RegisterCustomer(customer);

//     return Results.Ok("Customer registered successfully.");
// });


// // Cancel policy
// app.MapPost("/api/policies/cancel/{policyNumber}", (string policyNumber) =>
// {
//     SalesManager salesManager = new SalesManager();

//     salesManager.CancelPolicy(policyNumber);

//     return Results.Ok("Policy cancelled successfully.");
// });

// Send renewal reminder
app.MapPost("/api/policies/reminder/{policyNumber}", (string policyNumber) =>
{
    RenewalManager renewalManager = new RenewalManager();

    EmailNotificationService emailService =
        new EmailNotificationService();

    renewalManager.renewalReminderSent += emailService.OnRenewalReminderSent;

    renewalManager.SendRenewalReminder(policyNumber);

    return Results.Ok("Renewal reminder sent.");
});

// Generate policy document
app.MapPost("/api/policies/document/{policyNumber}", (string policyNumber) =>
{
    PolicyAdminManager policyAdminManager = new PolicyAdminManager();

    EmailNotificationService emailService =
        new EmailNotificationService();

    policyAdminManager.policyDocumentGenerated += emailService.OnPolicyDocumentSent;

    policyAdminManager.SendPolicyDocument(policyNumber);

    return Results.Ok("Policy document sent.");
});


app.Run();