// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

// Configure app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<LandUse.ModelInput, LandUse.ModelOutput>()
    .FromFile("LandUse.zip");
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Land Use", Description = "Docs for Land User API", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// Define prediction route & handler
app.MapPost("/predict",
    async (PredictionEnginePool<LandUse.ModelInput, LandUse.ModelOutput> predictionEnginePool, LandUse.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

// Run app
app.Run();