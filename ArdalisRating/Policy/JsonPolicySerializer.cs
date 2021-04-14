using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ArdalisRating.Policy
{
    public class JsonPolicySerializer : IJsonPolicySerializer
    {
        public PolicyModel GetPolicyFromJsonString(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<PolicyModel>(policyJson,
                    new StringEnumConverter());
            }
            catch
            {
                return new PolicyModel();
            }
        }

        public List<PolicyModel> GetPolicyListFromJsonString(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<PolicyModel>>(policyJson,
                    new StringEnumConverter());
            }
            catch
            {
                return new List<PolicyModel>();
            }
        }
    }
}
