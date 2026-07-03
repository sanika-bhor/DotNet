using MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Repositories;
using TFLCollections;
namespace MaxNewYorkInsurance.Departments;

public class ClaimDepartment
{



    public void OnClaimRegistered(Claim claim)
    {
        ClaimsRepository claimsRepository = new ClaimsRepository();
        PolicyRepository policyRepository = new PolicyRepository();
        TFLList<Policy> policies = policyRepository.GetAllPolicies();
        bool status = false;
        foreach (Policy policy in policies)
        {
            if (policy.PolicyNumber == claim.PolicyNumber)
            {
                TFLList<Claim> claims = claimsRepository.GetAllRegisterClaim();
                claims.AddNodeEnd(claim);
                claimsRepository.SaveRegisterClaim(claims);
                status = true;
                break;
            }
        }
        if (status)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Claims Department");
            Console.WriteLine($"Claim {claim.ClaimId} registered successfully.");
            Console.WriteLine("Claim forwarded for verification.");
            Console.WriteLine("====================================");
        }
        else
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Claims Department");
            Console.WriteLine($"Claim {claim.ClaimId} not  registered.");
            Console.WriteLine("====================================");
        }

    }

    public void OnClaimVerified(Claim claim)
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Claim {claim.ClaimId} has been verified.");
        Console.WriteLine("Supporting documents validated.");
        Console.WriteLine("====================================");
    }

    public void OnClaimApproved(Claim claim)
    {
        bool status = false;
        ClaimsRepository claimsRepository = new ClaimsRepository();
        TFLList<Claim> claims = claimsRepository.GetAllRegisterClaim();

        foreach (Claim claim2 in claims)
        {
            if (claim2.ClaimId == claim.ClaimId)
            {
                if (claim2.Status != "Approved")
                {
                    claim2.Status = "Approved";
                    claim2.Remarks = "Documents verified successfully";
                    // calculate approved amount (90% of claim) if needed
                    decimal approvedAmount = claim2.ClaimAmount * 90 / 100;
                    claim2.ApprovedAmount = approvedAmount;
                    claimsRepository.SaveRegisterClaim(claims);
                    status = true;
                    break;
                }
            }
        }
        if (status)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Claim {claim.ClaimId} approved.");
            Console.WriteLine("Settlement process initiated.");
            Console.WriteLine("====================================");
        }
        else
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Claim {claim.ClaimId} not approved .");
            Console.WriteLine("register claim first");
            Console.WriteLine("====================================");
        }


    }
    public void OnClaimRejected(Claim claim)
    {
        bool status = false;
        ClaimsRepository claimsRepository = new ClaimsRepository();
        TFLList<Claim> claims = claimsRepository.GetAllRegisterClaim();

        foreach (Claim claim2 in claims)
        {
            if (claim2.ClaimId == claim.ClaimId)
            {

                if (claim2.Status != "Approved")
                {
                    claim2.Status = "Rejected";
                    claim2.Remarks = "Documents not verified";
                    claimsRepository.SaveRegisterClaim(claims);
                    status = true;
                    break;
                }

            }
        }
        if (status)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Claim {claim.ClaimId} rejected.");
            Console.WriteLine("Customer will be notified with the reason.");
            Console.WriteLine("====================================");
        }
        else
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Claim {claim.ClaimId} approved.");
            Console.WriteLine("====================================");
        }
    }

    public void OnClaimSettled(Claim claim)
    {
        bool status = false;
        ClaimsRepository claimsRepository = new ClaimsRepository();
        TFLList<Claim> claims = claimsRepository.GetAllRegisterClaim();

        foreach (Claim claim2 in claims)
        {
            if (claim2.ClaimId == claim.ClaimId)
            {
                if (claim2.Status == "Approved")
                {
                    claim2.Status="Settled";
                    claim2.SettlementDate = DateTime.Now;
                    claimsRepository.SaveRegisterClaim(claims);
                    status = true;
                    break;
                }
            }
        }
        if (status)
        {
                Console.WriteLine("====================================");
            Console.WriteLine($"Claim {claim.ClaimId} settled successfully.");
            Console.WriteLine("Payment released to the customer.");
            Console.WriteLine("====================================");
        }
        else
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Claim {claim.ClaimId}  not settled.");
            Console.WriteLine("====================================");
        }
    }

    public void OnFraudCheckRequested(Claim claim)
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Fraud investigation initiated for Claim {claim.ClaimId}.");
        Console.WriteLine("Claim sent to the investigation team.");
        Console.WriteLine("====================================");
    }
    public void OnClaimReopened(Claim claim)
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Claim {claim.ClaimId} has been reopened.");
        Console.WriteLine("The claim will be reviewed again.");
        Console.WriteLine("====================================");
    }

    public void OnClaimClosed(Claim claim)
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Claim {claim.ClaimId} closed.");
        Console.WriteLine("No further processing is pending.");
        Console.WriteLine("====================================");
    }

}
