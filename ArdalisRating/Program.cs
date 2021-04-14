using ArdalisRating.Policy;
using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            IFilePolicySource _policySource = new FilePolicySource();
            IJsonPolicySerializer jsonPolicSerializer = new JsonPolicySerializer();
            var mylist = jsonPolicSerializer.GetPolicyListFromJsonString(_policySource.GetPolicyFromSource("policyList.json"));

            foreach (var policy in mylist)
            {
                var engine = new RatingEngine(policy);
                engine?.Rate();

                if (engine?.Rating > 0)
                {
                    Console.WriteLine($"Rating: {engine.Rating}");
                }
                else
                {
                    Console.WriteLine("No rating produced.");
                }
            }
        }
    }
}
