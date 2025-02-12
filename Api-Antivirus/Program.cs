using DotNetEnv;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Api_Antivirus.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

Env.Load(); //Carga las variables de .env

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    EnvironmentName = environment
    
});

// Habilitar los Static Web Assets en todos los entornos, incluyendo "Local"
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

if (environment == "Development")
{
    String conectionString = $"Host={Environment.GetEnvironmentVariable("HOST")};" +
        $"Port={Environment.GetEnvironmentVariable("PORT")};" +
        $"Database={Environment.GetEnvironmentVariable("DATABASE")};" +
        $"Username={Environment.GetEnvironmentVariable("USERNAME")};" +
        $"Password={Environment.GetEnvironmentVariable("PASSWORD")};";

    //sobreescribir valores de appsettings.json con variables de entorno
    builder.Configuration["ConnectionStrings:DefaultConnection"] = conectionString;

}
else
{
    Console.WriteLine("Entorno Local");
}

// Agregar conexión a PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    Console.WriteLine("Swagger");
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
