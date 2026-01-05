using ArdalisRating;
using WebRating;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new RawJsonBodyInputFormatter());
});

// Register application services
builder.Services.AddScoped<RatingEngine>();
builder.Services.AddScoped<RaterFactory>();
builder.Services.AddScoped<StringPolicySource>();
builder.Services.AddScoped<IPolicySource, StringPolicySource>(sp => sp.GetRequiredService<StringPolicySource>());
builder.Services.AddScoped<ArdalisRating.ILogger, NullLogger>();
builder.Services.AddScoped<IPolicySerializer, JsonPolicySerializer>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
});

app.UseHttpsRedirection();

// Add a simple root endpoint
app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();

app.Run();
