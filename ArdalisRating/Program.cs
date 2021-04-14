using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating;
using System;
using System.Collections.Generic;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            IPolicyRatingContext context = new DefaultRatingContext();
            ILogger logger = new FileLogger();

            logger.Log("Ardalis Insurance Rating System Starting...");

            IPolicySource _policySource = new FilePolicySource();
            IJsonPolicySerializer jsonPolicSerializer = new JsonPolicySerializer();
            logger.Log("Loading Policy Lists");
            var mylist = jsonPolicSerializer.GetPolicyListFromJsonString(_policySource.GetPolicyFromSource("policyList.json"));
            logger.Log($"Found {mylist?.Count} policies to process.");

            foreach (var policy in mylist??new List<PolicyModel>())
            {
                logger.Log($"Process a {policy?.Type} policy.");
                var engine = new RatingEngine(policy, context, logger);
                engine.Rate();

                if (engine?.Rating > 0)
                {
                    logger.Log($"Rating: {engine.Rating}");
                }
                else
                {
                    logger.Log("No rating produced.");
                }
            }
        }
    }
}
