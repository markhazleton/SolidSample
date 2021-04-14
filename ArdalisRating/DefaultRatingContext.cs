﻿using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating;
using System;

namespace ArdalisRating
{
    public class DefaultRatingContext : IPolicyRatingContext
    {
        public RatingEngine Engine { get; set; }

        public Rater CreateRaterForPolicy(PolicyModel policy, IPolicyRatingContext context)
        {
            return new RaterFactory().Create(policy, context);
        }

        public PolicyModel GetPolicyFromJsonString(string policyJson)
        {
            return new JsonPolicySerializer().GetPolicyFromJsonString(policyJson);
        }

        public PolicyModel GetPolicyFromXmlString(string policyXml)
        {
            throw new NotImplementedException();
        }

        public string LoadPolicyFromFile()
        {
            return new FilePolicySource().GetPolicyFromSource("policy.json");
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }
    }
}
