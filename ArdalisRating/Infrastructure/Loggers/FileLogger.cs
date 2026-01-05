namespace ArdalisRating;

public class FileLogger : ILogger
{
    private const string LogFileName = "log.txt";

    public void Log(string message)
    {
        using var stream = File.AppendText(LogFileName);
        stream.WriteLine(message);
        stream.Flush();
    }
}
