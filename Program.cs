using Microsoft.EntityFrameworkCore;

using ASPNET_006_Book_Vault.Data;
using ASPNET_006_Book_Vault.Repositories;
using ASPNET_006_Book_Vault.Repositories.Interfaces;
using ASPNET_006_Book_Vault.Services;
using ASPNET_006_Book_Vault.Services.Interfaces;

/*** Loading Environment Variables ***/
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

/*** Registering Services ***/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MSSQLConnectionString")
));

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

/*** Registering Routes ***/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

/*** Initial Data Seeding ***/
InitDB.Initialize(app, app.Environment.IsProduction());

app.Run();