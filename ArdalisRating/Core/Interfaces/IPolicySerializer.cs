using ArdalisRating.Core.Models;
using System.Collections.Generic;

namespace ArdalisRating.Core.Interfaces
{
    public interface IPolicySerializer
    {
        IPolicyModel GetPolicyFromString(string policyJson);

        public List<PolicyModel> GetPolicyListFromString(string policyJson);
    }
}