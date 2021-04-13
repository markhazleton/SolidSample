using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating.Policy
{
    public class PolicySerializer : IPolicySerializer
    {
        public PolicyModel GetPolicyFromJson(string policyJson)
        {
            return JsonConvert.DeserializeObject<PolicyModel>(policyJson,
                new StringEnumConverter());
        }
    }
}
