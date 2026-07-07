
using MaxNewYorkInsurance.Models;
using System.Text.Json;

using TFLCollections;

namespace MaxNewYorkInsurance.Repositories;

public class PremiumRepository
{
public TFLDoublyList<Premium> GetAllPremimum()
    {
        string fileName = @"A:\TAP\GitHub\DotNet\insuranceapp\InsuranceRestAPIApp\InsuranceRestAPIApp\Data\premiums.json";
        string jsonString = File.ReadAllText(fileName);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        TFLDoublyList<Premium>? premiums = JsonSerializer.Deserialize<TFLDoublyList<Premium>>(jsonString, options);
        return premiums;
    }


    public bool SaveAllPremium(TFLDoublyList<Premium> premiums)
    {
        bool status = false;
        string fileName = @"A:\TAP\GitHub\DotNet\insuranceapp\InsuranceRestAPIApp\InsuranceRestAPIApp\Data\premiums.json";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        string jsonString = JsonSerializer.Serialize(premiums, options);
        File.WriteAllText(fileName, jsonString);
        status = true;
        return status;
    }


}