using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ArdalisRating.Infrastructure
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public IPolicyModel GetPolicyFromString(string policyJson)
        {
            try
            {
                var myPolicy = JsonConvert.DeserializeObject<PolicyModel>(policyJson,
                    new StringEnumConverter());
                return myPolicy;
            }
            catch
            {
                return new PolicyModel();
            }
        }

        public List<PolicyModel> GetPolicyListFromString(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<PolicyModel>>(policyJson,
                    new StringEnumConverter());
            }
            catch
            {
                var myList = new List<PolicyModel>();
                return myList;
            }
        }
    }
}