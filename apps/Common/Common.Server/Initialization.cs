namespace TEI.Common.Server;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TEI.Database.Model.Context;
using TEI.Database.Server.Access;

public static class Initialization
{
    public static void ConfigureLoggingServices(IHostApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        bool enableSensitiveDbLogging = builder.Configuration.GetRequiredSection("EnableSensitiveDbLogging").Get<bool>();
        if (enableSensitiveDbLogging)
        {
            builder.Logging.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Debug);
        }

        builder.Services.AddTransient<IBgcRepository, BgcRepository>();
    }

    public static void ConfigureDatabaseServices(IHostApplicationBuilder builder)
    {
        bool enableSensitiveDbLogging = builder.Configuration.GetRequiredSection("EnableSensitiveDbLogging").Get<bool>();
        string connectionString = GetConnectionString(builder.Configuration);

        builder.Services.AddDbContextPool<TeiDbContext>(
            opt => opt.UseNpgsql(connectionString, o => o.SetPostgresVersion(17, 0))
                .EnableSensitiveDataLogging(enableSensitiveDbLogging));
    }

    public static void ConfigureMappingServices(IHostApplicationBuilder builder, params Type[] prototypicalAssemblyTypes)
    {
        builder.Services.AddAutoMapper(config => config.DestinationMemberNamingConvention = new ExactMatchNamingConvention(), prototypicalAssemblyTypes);
    }

    private static string GetConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("TEI") ?? throw new InvalidOperationException("Database connection string is undefined");
    }
}
