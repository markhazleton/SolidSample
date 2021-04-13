using System;

namespace ArdalisRating.Policy
{
    public interface IPolicySerializer
    {
        PolicyModel GetPolicyFromJsonString(string policyJson);
    }
}
