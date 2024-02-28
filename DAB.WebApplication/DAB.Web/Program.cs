using DAB.Data;
using DAB.Domain.Entities;
using DAB.Domain.IEntities;
using DAB.Service.IRepository;
using DAB.Service.Repository;
using DAB.Web.Models;

using DBA.RespositoriesService1;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DabDbContext");
//builder.Services.AddDbContext<DabDbContext>( options =>
  //  options.UseSqlServer( connectionString ) );

builder.Services.AddRazorPages();




string conStr = builder.Configuration.GetConnectionString("MyConn");

builder.Services.AddDbContext<DabDbContext>( options => options.UseSqlServer( @conStr ) );

builder.Services.AddScoped<Iservice1, Service1>();


builder.Services.AddScoped<IBoissonRepo, BoissonRepository>();
builder.Services.AddScoped<IRecetteIngrediantRepository,RecetteIngrediantRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

builder.Services.AddScoped<IRecetteRepository, RecetteRepository>();



builder.Services.AddScoped<IBoisson, Boisson>();
builder.Services.AddScoped<IRecette, Recette>();
builder.Services.AddScoped<IIngredient, Ingredient>();
builder.Services.AddScoped<IRecetteIngredient, RecetteIngredient>();

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
    pattern: "{controller= Home}/{action=Index}/{id?}" );

app.MapControllerRoute(
    name: "Boisson",
    pattern: "{controller=Boisson}/{action=create}/{id?}" );


app.MapControllerRoute(
    name: "AllIngrediant",
    pattern: "{controller=Ingrediant}/{action=FindAll_Ingrediant}/{id?}" );


app.Run();
