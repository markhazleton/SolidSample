using System;

namespace ArdalisRating.Policy
{
    public interface IPolicySerializer
    {
        PolicyModel GetPolicyFromJson(string policyJson);
    }
}
