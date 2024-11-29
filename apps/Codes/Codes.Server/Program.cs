#pragma warning disable CA1506
using TEI.Codes.Server.Components;
using TEI.Codes.Server.Services;
using TEI.Common.Server;
using _Imports = TEI.Codes.Client._Imports;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Initialization.ConfigureLoggingServices(builder);
Initialization.ConfigureDatabaseServices(builder);
Initialization.ConfigureMappingServices(builder, typeof(Program));

builder.Services.AddTransient<IMappingService, MappingService>();

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapControllers();
app.MapHealthChecks("/health");
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(_Imports).Assembly);

app.Run();
#pragma warning restore CA1506
#pragma warning restore CA1506
