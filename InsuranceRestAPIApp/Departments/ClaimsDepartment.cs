using MaxNewYorkInsurance.Agents;
using  MaxNewYorkInsurance.Models;
using MaxNewYorkInsurance.Repositories;
namespace MaxNewYorkInsurance.Departments;
class ClaimDepartment
{

    public void OnClaimRegistered(Claim theClaim)
    {
        ClaimsRepository claimsRepository= new ClaimsRepository();
        List<Claim> claims = claimsRepository.GetAllRegisterClaim();
        claims.Add(theClaim);
        claimsRepository.SaveRegisterClaim(claims);

        Console.WriteLine($"Claim created. for {theClaim.PolicyNumber}  policy ");
        Console.WriteLine($"Claim amount {theClaim.ClaimAmount} Rs");
        
    
    }

  

   
}
 