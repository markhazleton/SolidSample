using ArdalisRating.Core.Models;
using System;
using System.Collections.Generic;

namespace ArdalisRating.Core.Interfaces
{
    public interface IJsonPolicySerializer
    {
        PolicyModel GetPolicyFromJsonString(string policyJson);
        public List<PolicyModel> GetPolicyListFromJsonString(string policyJson);
    }
}
