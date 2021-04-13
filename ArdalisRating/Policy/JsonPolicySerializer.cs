using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating.Policy
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public PolicyModel GetPolicyFromJsonString(string policyJson)
        {
            return JsonConvert.DeserializeObject<PolicyModel>(policyJson,
                new StringEnumConverter());
        }
    }
}
