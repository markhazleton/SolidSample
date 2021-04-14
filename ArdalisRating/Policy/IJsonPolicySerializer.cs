using System;
using System.Collections.Generic;

namespace ArdalisRating.Policy
{
    public interface IJsonPolicySerializer
    {
        PolicyModel GetPolicyFromJsonString(string policyJson);
        public List<PolicyModel> GetPolicyListFromJsonString(string policyJson);
    }
}
