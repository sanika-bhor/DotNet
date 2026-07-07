
using MaxNewYorkInsurance.Models;
using System.Text.Json;

using TFLCollections;

namespace MaxNewYorkInsurance.Repositories;

public class PolicyRepository
{
    
    public TFLDoublyList<Policy> GetAllPolicies()
    {
        string fileName = @"A:\TAP\GitHub\DotNet\insuranceapp\InsuranceRestAPIApp\InsuranceRestAPIApp\Data\policies.json";
        string jsonString = File.ReadAllText(fileName);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // TFLDoublyList<Policy>? policies = JsonSerializer.Deserialize<TFLDoublyList<Policy>>(jsonString, options);
        List<Policy> policies = JsonSerializer.Deserialize<List<Policy>>(jsonString, options);
        TFLDoublyList<Policy> tPolicies =new TFLDoublyList<Policy>();
        foreach(Policy thePolicy in policies)
        {
            tPolicies.InsertAtLast(thePolicy);
        } 
        return tPolicies;
    }


    public bool SaveAllPolicies(TFLDoublyList<Policy> policies)
    {
        bool status = false;
        string fileName = @"A:\TAP\GitHub\DotNet\insuranceapp\InsuranceRestAPIApp\InsuranceRestAPIApp\Data\policies.json";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        string jsonString = JsonSerializer.Serialize(policies, options);
        File.WriteAllText(fileName, jsonString);
        status = true;
        return status;


        
    }

}