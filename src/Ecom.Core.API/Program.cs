using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ecom.Core.Application;
using Ecom.Core.Infrastructure;
using Host;
using Host.Services;
using Microsoft.EntityFrameworkCore;
using MinimalAPI;
using MinimalAPI.OpenApi;
using MinimalAPI.SwaggerUI;
using Services.Autofac.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appName = builder.Environment.ApplicationName;
var configuration = builder.Configuration;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // Register application and infrastructure services with Autofac
    containerBuilder.AddApplicationServices().AddInfrastructureServices();
});

var versioningOptions = new DefaultVersioningOptions
{
    BaseRouteTemplate = "api",
    DefaultVersion = 1,
    AssumeDefaultVersionWhenUnspecified = true,
    GenerateSwaggerDocs = true,
};

// Configure Serilog
builder.AddSerilog(configuration, appName);

// Add health checks
builder.Services.AddHealthChecks();

// Add API Explorer services (required for Swagger with minimal APIs)
builder.Services.AddEndpointsApiExplorer();

// Register other services
builder
    .Services.AddCorsServices(configuration)
    .AddMinimalApiWithSwaggerUI(
        title: "Ecom.Core API",
        version: "v1",
        description: "Ecom.Core API for e-commerce applications",
        assemblies:
        [
            typeof(Program).Assembly,
            typeof(Ecom.Core.Application.Register).Assembly,
            typeof(Ecom.Core.Infrastructure.Register).Assembly,
        ]
    )
    .AddAutofac()
    .AddGlobalExceptionHandling(appName)
    .AddHealthCheck(configuration)
    // Register Infrastructure and Application services
    .AddInfrastructureServices(configuration)
    .AddApplicationServices(configuration);

var app = builder.Build();

app.MapMinimalEndpoints(versioningOptions, typeof(Program).Assembly);

if (app.Environment.IsDevelopment())
{
    app.UseMinimalApiOpenApi();

    app.UseMinimalApiDocs(
        swaggerRoutePrefix: "docs",
        enableTryItOut: true,
        enableDeepLinking: true,
        enableFilter: true
    );
}

app.UseHttpsRedirection();

// Configure CORS
// app.UseCorsServices(configuration);

// Configure Global Exception Handling
app.UseGlobalExceptionHandling();

// Configure ARM Elastic (disable in Kubernetes to prevent connection issues)
if (!builder.Environment.IsProduction())
{
    app.UseElasticApm(configuration);
}

app.UseRouting();

// Configure Health Check endpoint
app.MapHealthChecks("/health");

// Map all endpoints from the assembly

await app.RunAsync();
