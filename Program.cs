using ASPNET_006_Book_Vault.Data;
using ASPNET_006_Book_Vault.Repositories;
using ASPNET_006_Book_Vault.Repositories.Interfaces;
using ASPNET_006_Book_Vault.Services;
using ASPNET_006_Book_Vault.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Text.Json;

/*** Loading Environment Variables ***/
DotNetEnv.Env.Load();

try
{
    Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

    /*** App Initialization ***/
    var builder = WebApplication.CreateBuilder(args);

    /*** Serilog Configuration ***/
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.MSSqlServer(
            connectionString: Environment.GetEnvironmentVariable("MSSQL_CONNECTION_STRING"),
            sinkOptions: new MSSqlServerSinkOptions
            {
                TableName = "Logs",
                // AutoCreateSqlTable = true
            }
        )
        .CreateLogger();

    Log.Information("Starting up the Book Vault API...");

    builder.Host.UseSerilog();

    /*** Registering Services ***/
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("MSSQL_CONNECTION_STRING")
    ));
    builder.Services.AddApiVersioning(config =>
    {
        config.DefaultApiVersion = new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
    });
    builder.Services.AddHealthChecks()
        .AddDbContextCheck<AppDbContext>("Microsoft SQL Health Check", HealthStatus.Unhealthy);

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IBookService, BookService>();

    var app = builder.Build();

    /*** Registering Middleware ***/
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    // app.UseHttpsRedirection();
    app.UseCors("AllowAll");
    app.UseRouting();
    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = async (context, report) =>
        {
            context.Response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new
            {
                status = report.Status.ToString(),
                health_checks = report.Entries.Select(entry => new
                {
                    name = entry.Key,
                    status = entry.Value.Status.ToString(),
                    description = entry.Value.Description
                })
            });

            await context.Response.WriteAsync(result);
        }
    });

    /*** Registering Routes ***/
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    /*** Initial Data Seeding ***/
    InitDB.Initialize(app, app.Environment.IsProduction());

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception during startup.");
}
finally
{
    Log.Information("Shutting down Book Vault API.");
    Log.CloseAndFlush();
}