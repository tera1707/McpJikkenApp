using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using System.Net.Http.Headers;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithResourcesFromAssembly()
    .WithPromptsFromAssembly()
    .WithToolsFromAssembly();

var app = builder.Build();

await app.RunAsync();
