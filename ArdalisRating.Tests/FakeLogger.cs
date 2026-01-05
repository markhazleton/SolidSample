namespace ArdalisRating.Tests;

public class FakeLogger : ILogger
{
    public List<string> LoggedMessages { get; } = new();

    public void Log(string message)
    {
        LoggedMessages.Add(message);
    }
}
