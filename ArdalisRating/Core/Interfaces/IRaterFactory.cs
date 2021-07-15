using ArdalisRating.Core.Raters;

namespace ArdalisRating.Core.Interfaces
{
    /// <summary>
    /// Rater Factory Interface
    /// </summary>
    public interface IRaterFactory
    {
        Rater Create(IPolicyModel policy, IBatchLogger logger);
    }
}