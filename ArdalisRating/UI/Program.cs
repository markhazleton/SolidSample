using ArdalisRating.Core;
using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Models;
using ArdalisRating.Core.Raters;
using ArdalisRating.Infrastructure;
using ArdalisRating.Infrastructure.Logger;
using System;
using System.Collections.Generic;

namespace ArdalisRating.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();

            logger.Log("*********  Ardalis Insurance Rating System Starting **********");

            IPolicySource _policySource = new FilePolicySource();
            IJsonPolicySerializer jsonPolicSerializer = new JsonPolicySerializer();
            logger.Log("Loading Policy Lists");
            var mylist = jsonPolicSerializer.GetPolicyListFromJsonString(_policySource.GetPolicyFromSource("policyList.json"));
            logger.Log($"Found {mylist?.Count} policies to process.");
            int policyCount = 0;

            foreach (var policy in mylist ?? new List<PolicyModel>())
            {
                policyCount++;
                logger.Log($"{policyCount} *********  Process a {policy?.Type} policy.");
                var engine = new RatingEngine(policy, logger, new RaterFactory());
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
