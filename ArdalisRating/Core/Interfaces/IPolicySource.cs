namespace ArdalisRating.Core.Interfaces
{
    public interface IPolicySource
    {
        string PolicySource { get; set; }

        string GetPolicyFromSource();
    }
}