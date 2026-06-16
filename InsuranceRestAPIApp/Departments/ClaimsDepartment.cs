using MaxNewYorkInsurance.Agents;
using  MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Repositories;
namespace MaxNewYorkInsurance.Departments;
class ClaimDepartment
{

    public void OnClaimRegistered(Claim claim)
    {
        ClaimsRepository claimsRepository= new ClaimsRepository();
        List<Claim> claims = claimsRepository.GetAllRegisterClaim();
        claims.Add(claim);
        claimsRepository.SaveRegisterClaim(claims);

        Console.WriteLine($"Claim created. for {claim.PolicyNumber}  policy ");
        Console.WriteLine($"Claim amount {claim.ClaimAmount} Rs");
        
    
    }

  

   
}
 