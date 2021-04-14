using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating;
using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            IPolicyRatingContext context = new DefaultRatingContext();

            context.Log("Ardalis Insurance Rating System Starting...");

            IFilePolicySource _policySource = new FilePolicySource();
            IJsonPolicySerializer jsonPolicSerializer = new JsonPolicySerializer();
            context.Log("Loading Policy Lists");
            var mylist = jsonPolicSerializer.GetPolicyListFromJsonString(_policySource.GetPolicyFromSource("policyList.json"));
            context.Log($"Found {mylist.Count} policies to process.");

            foreach (var policy in mylist)
            {
                context.Log($"Process a {policy.Type} policy.");
                var engine = new RatingEngine(policy,context);
                engine.Rate();

                if (engine?.Rating > 0)
                {
                    context.Log($"Rating: {engine.Rating}");
                }
                else
                {
                    Console.WriteLine("No rating produced.");
                }
            }
        }
    }
}
