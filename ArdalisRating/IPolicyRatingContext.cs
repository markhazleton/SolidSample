using ArdalisRating.Logger;
using ArdalisRating.Policy;
using ArdalisRating.Rating;
using System;

namespace ArdalisRating
{
    public interface IPolicyRatingContext
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        PolicyModel GetPolicyFromJsonString(string policyJson);
        PolicyModel GetPolicyFromXmlString(string policyXml);
        Rater CreateRaterForPolicy(PolicyModel policy, IPolicyRatingContext context, ILogger logger);
        RatingEngine Engine { get; set; }
    }
}
