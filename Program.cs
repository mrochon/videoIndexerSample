// See https://aka.ms/new-console-template for more information
using VISample.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using VISample.Services;
using Azure.Core;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.Sources.Clear();
IHostEnvironment env = builder.Environment;
builder.Configuration
    .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appSettings.{env.EnvironmentName}.json", true, true)
    .AddUserSecrets<Program>();

builder.Services.AddOptions()
    .Configure<VideoIndexerOptions>(builder.Configuration.GetSection("VideoIndexer"))
    .AddLogging(builder => builder.AddConsole())
    .AddSingleton<TokenCredential>(new DefaultAzureCredential())
    .AddHttpClient()
    .AddTransient<VideoClient>()
    .AddHostedService<VISample.Main>();

builder.Build().Run();