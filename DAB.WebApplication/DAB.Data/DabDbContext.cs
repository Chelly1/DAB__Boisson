using DAB.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Data
 {
 public class DabDbContext : DbContext
  {

  public DabDbContext ( DbContextOptions<DabDbContext> options ) : base( options ) { }




  public DbSet<Boisson> Boissons { get; set; }

  public DbSet<Ingredient> Ingredients { get; set; }

  public DbSet<Recette> Recettes { get; set; }

  public DbSet<RecetteIngredient> RecetteIngredients { get; set; }

  public DabDbContext () { }

  protected override void OnModelCreating ( ModelBuilder modelBuilder )
   {
   modelBuilder.Entity<Boisson>()
    .HasKey( k => k.Id );


   // .WithMany( l => l.Ingredients ).
   // .
   modelBuilder.Entity<Ingredient>()
   .HasKey( k => k.Id );

   modelBuilder.Entity<Recette>()
   .HasKey( k => k.Id );

   modelBuilder.Entity<RecetteIngredient>().HasKey(
    sc => new { sc.Ingredient_Id, sc.Recette_Id } );
  
   }   
  
  }
 }
