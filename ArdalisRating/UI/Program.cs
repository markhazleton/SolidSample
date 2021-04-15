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
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IBatchLogger logger = new InMemoryLogger();
            IRatingEngine engine;

            logger.Log("*********  Ardalis Insurance Rating System Starting **********");
            IPolicySerializer jsonPolicySerializer = new JsonPolicySerializer();
            IPolicySource _policySource = new FilePolicySource("policy.json");
            IPolicyModel myPolicy = jsonPolicySerializer.GetPolicyFromString(_policySource.GetPolicyFromSource());
            engine = new RatingEngine(logger, new RaterFactory());
            engine.Rate(myPolicy);

            if (engine?.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }

            _policySource.PolicySource = "policyList.json";
            logger.Log("Loading Policy Lists");
            var mylist = jsonPolicySerializer.GetPolicyListFromString(_policySource.GetPolicyFromSource());
            logger.Log($"Found {mylist?.Count} policies to process.");
            int policyCount = 0;
            foreach (var policy in mylist ?? new List<PolicyModel>())
            {
                policyCount++;
                logger.Log($"{policyCount} *********  Process a {policy?.Type} policy.");
                engine = new RatingEngine(logger, new RaterFactory());
                engine.Rate(policy);

                if (engine?.Rating > 0)
                {
                    logger.Log($"Rating: {engine.Rating}");
                }
                else
                {
                    logger.Log("No rating produced.");
                }
            }

            foreach (var message in logger.LogList())
            {
                Console.WriteLine(message);
            }

        }
    }
}
