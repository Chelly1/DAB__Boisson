using DAB.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DAB.Data
{
    public class DabDbContext : DbContext
    {

        public DabDbContext(DbContextOptions<DabDbContext> options) : base(options)
        {
        }

        public DbSet<Boisson> Boissons { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recette> Recettes { get; set; }

        public DbSet<RecetteIngredient> RecetteIngredients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boisson>()
             .HasKey(b => b.Id);
            modelBuilder.Entity<Ingredient>()
             .HasKey(b => b.Id);

            modelBuilder.Entity<Recette>()
           .HasKey(r => r.Id);

            modelBuilder.Entity<RecetteIngredient>()
                .HasKey(r => r.Id);


            modelBuilder.Entity<Recette>()
            .HasMany(b => b.RecetteIngredients)
             .WithOne(ri => ri.Recette)
             .HasForeignKey(f => f.RecetteId);







            modelBuilder.Entity<Recette>()
       .HasOne(r => r.Boisson)
       .WithOne(b => b.Recette)
       .HasForeignKey<Boisson>(b => b.RecetteId)
       .IsRequired();




            //modelBuilder.Entity<RecetteIngredient>()
            //.HasKey(ri => new { ri.RecetteId, ri.IngredientId });


            modelBuilder.Entity<RecetteIngredient>()
   .HasOne(ri => ri.Recette)
   .WithMany(r => r.RecetteIngredients)
   .HasForeignKey(ri => ri.RecetteId);

            modelBuilder.Entity<RecetteIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecetteIngredients)
            .HasForeignKey(ri => ri.IngredientId);
        }
    }
}
