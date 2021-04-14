using ArdalisRating.Policy;
using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(PolicyModel policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                        new object[] { engine, engine._logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
