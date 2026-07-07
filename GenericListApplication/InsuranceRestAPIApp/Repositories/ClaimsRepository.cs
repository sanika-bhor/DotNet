
using MaxNewYorkInsurance.Models;
using System.Text.Json;

using TFLCollections;

namespace MaxNewYorkInsurance.Repositories;

public class ClaimsRepository
{
    
    public TFLDoublyList<Claim> GetAllRegisterClaim()
    {
        string fileName = @"A:\TAP\GitHub\DotNet\insuranceapp\InsuranceRestAPIApp\InsuranceRestAPIApp\Data\claimrequests.json";
        string jsonString = File.ReadAllText(fileName);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        TFLDoublyList<Claim>? RegisterClaims = JsonSerializer.Deserialize<TFLDoublyList<Claim>>(jsonString, options);
        return RegisterClaims;
    }

    public bool SaveRegisterClaim(TFLDoublyList<Claim> claims)
    {
        bool status = false;
        string fileName = @"A:\TAP\GitHub\DotNet\insuranceapp\InsuranceRestAPIApp\InsuranceRestAPIApp\Data\claimrequests.json";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        string jsonString = JsonSerializer.Serialize(claims, options);
        File.WriteAllText(fileName, jsonString);
        status = true;
        return status;
    }
}