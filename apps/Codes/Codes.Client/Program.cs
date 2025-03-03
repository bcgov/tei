using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using TEI.Codes.Client.Api;
using TEI.Codes.Client.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

Uri baseAddress = new(builder.HostEnvironment.BaseAddress);
builder.Services.AddTransient(_ => new HttpClient { BaseAddress = baseAddress });
builder.Services.AddRefitClient<IClassificationApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new(baseAddress, "Classification"));
builder.Services.AddSingleton<IClassificationFilterService, ClassificationFilterService>();

await builder.Build().RunAsync();
