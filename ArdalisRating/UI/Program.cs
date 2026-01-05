using ArdalisRating;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register services
builder.Services.AddSingleton<ILogger, FileLogger>();
builder.Services.AddSingleton<IPolicySource, FilePolicySource>();
builder.Services.AddSingleton<IPolicySerializer, JsonPolicySerializer>();
builder.Services.AddSingleton<RaterFactory>();
builder.Services.AddTransient<RatingEngine>();

var host = builder.Build();

Console.WriteLine("Ardalis Insurance Rating System Starting...");

var engine = host.Services.GetRequiredService<RatingEngine>();
engine.Rate();

if (engine.Rating > 0)
{
    Console.WriteLine($"Rating: {engine.Rating}");
}
else
{
    Console.WriteLine("No rating produced.");
}
