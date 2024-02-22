using DAB.Data;
using DAB.Service.IRepository;
using DAB.Service.Repository;
using DAB.Web.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
var conn = builder.Configuration.GetConnectionString("DabDbContext");
builder.Services.AddDbContext<DabDbContext>( q => q.UseSqlServer( conn) );






builder.Services.AddSingleton<IboissonRepo, BoissonRepository>();

builder.Services.AddScoped<IboissonRepo, BoissonRepository>();
builder.Services.AddSingleton<IboissonRepo, BoissonRepository>();



builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddSingleton<IIngredientRepository, IngredientRepository>();


builder.Services.AddScoped<IRecetteRepository, RecetteRepository>();
builder.Services.AddSingleton<IRecetteRepository, RecetteRepository>();


builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecetteRepository, RecetteRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() )
 {
 app.UseExceptionHandler( "/Home/Error" );
 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
 app.UseHsts();
 }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller= Boisson}/{action=create}/{id?}" );

app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Home}/{action=Index}/{id?}" );


app.Run();
