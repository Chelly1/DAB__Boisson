﻿// <auto-generated />
using System;
using DAB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAB.Data.Migrations
{
    [DbContext(typeof(DabDbContext))]
    [Migration("20240702175335_test4")]
    partial class test4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAB.Domain.Entities.Boisson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Boisson_Stock")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecetteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecetteId")
                        .IsUnique();

                    b.ToTable("Boissons");
                });

            modelBuilder.Entity("DAB.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DAB.Domain.Entities.Recette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recettes");
                });

            modelBuilder.Entity("DAB.Domain.Entities.RecetteIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Dose")
                        .HasColumnType("float");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("RecetteId")
                        .HasColumnType("int");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecetteId");

                    b.ToTable("RecetteIngredients");
                });

            modelBuilder.Entity("DAB.Domain.Entities.Boisson", b =>
                {
                    b.HasOne("DAB.Domain.Entities.Recette", "Recette")
                        .WithOne("Boisson")
                        .HasForeignKey("DAB.Domain.Entities.Boisson", "RecetteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recette");
                });

            modelBuilder.Entity("DAB.Domain.Entities.RecetteIngredient", b =>
                {
                    b.HasOne("DAB.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("RecetteIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB.Domain.Entities.Recette", "Recette")
                        .WithMany("RecetteIngredients")
                        .HasForeignKey("RecetteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recette");
                });

            modelBuilder.Entity("DAB.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("RecetteIngredients");
                });

            modelBuilder.Entity("DAB.Domain.Entities.Recette", b =>
                {
                    b.Navigation("Boisson")
                        .IsRequired();

                    b.Navigation("RecetteIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
