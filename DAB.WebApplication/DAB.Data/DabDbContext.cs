using DAB.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Data
 {
 public class DabDbContext : DbContext
  {
  public DabDbContext( DbContextOptions<DabDbContext> options ) : base( options ) { }

  public DbSet<Boisson> Boissons{ get; set; }

  public DbSet<Ingredient> Ingredients { get; set; }

  public DbSet<Recette> Recettes { get; set; }

  public DabDbContext() { }

  protected override void OnModelCreating ( ModelBuilder modelBuilder )
   {
   modelBuilder.Entity<Boisson>()
       .HasKey( b => b.Id );

   modelBuilder.Entity<Ingredient>()
    .HasKey( b => b.Id );

   modelBuilder.Entity<Recette>()
    .HasKey( b => b.Id );
   base.OnModelCreating( modelBuilder );

   }

  }
 }
