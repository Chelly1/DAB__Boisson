using DAB.Data;
using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Repository
 {
 public class BoissonRepository : IboissonRepo
  {
  private readonly DabDbContext _dbContext = new DabDbContext();
  /// <summary>
  /// jout boisson à la machine
  /// </summary>
  /// <param name="boisson"></param>
  /// <exception cref="NotImplementedException"></exception>
  public void AddBoisson ( Boisson boisson )
   {
   if ( boisson == null )
    { throw new BoissonNotFoundException(); }
   else
    {
    _dbContext.Boissons.Add( boisson );

    }
   }

  /// <summary>
  /// Ajout nouveau boisson dans le distributeur automatique
  /// </summary>
  /// <param name="boisson"></param>
  /// <param name="stock"></param>
  /// <exception cref="NotImplementedException"></exception>
  public void AddBoissonStock ( Boisson boisson, int stock )
   {
   if ( boisson == null ) throw new ArgumentNullException( "veuillez choisir ajouter un boisson" );
    {
    if ( stock > 0 )
     boisson.BoissonStock = +stock;
    }
   }


  public Double CalculBoissonPrix ( Boisson boisson )
   {
   Double _Pris = 0;

   if ( boisson == null )
    {
    throw new BoissonNotFoundException( "Boisson not found" );
    }
   else
    {
    List<Ingredient> ingredientsList = FindBoissantIngredients(boisson).ToList() ;

    if ( ingredientsList == null )
     {
     throw new BoissonNotFoundException( "erreur boissan  ingridient" );
     }
    else
     {
     foreach ( var ing in ingredientsList )
      {
      if ( ing != null && ing.Price > 0 )
       {
       _Pris = +ing.Price;
       }
      }
     }

    }
   return _Pris;
   }

  public ICollection<Boisson> FindAllBoisson ()
   {List<Boisson> boissons= _dbContext.Boissons.ToList() ;
    if ( boissons == null )
     {
     throw new BoissonNotFoundException( "yooooooooo hneeeeeeee" );
     }
    else
     {
     return boissons.ToList();
     }
   }

  public ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson )
   {
   List<Ingredient> _IngredientsResults = new List<Ingredient>();
   if ( boisson == null )
    {
    throw new BoissonNotFoundException( "booisson non trouver" );
    }
   else
    {
    if ( boisson.Recette != null && boisson.Recette.Ingredients.Count() > 0 )
     {
     _IngredientsResults = boisson.Recette.Ingredients.ToList();
     }
    }
   return _IngredientsResults ?? _IngredientsResults.ToList();
   }

  public Boisson? FindBoissonByName ( string name )
   {
   if ( name == null )
    {
    throw new BoissonNotFoundException( "veeuillez ecrire le nom du boisson demandé" );
    }
   else
    {
    return _dbContext.Boissons.Where( b => b.Name.Equals( name ) ).FirstOrDefault() ?? throw new BoissonNotFoundException( "boisson not found" );
    }
   }
  /// <summary>
  /// find la frecette du boisson selectionner
  /// </summary>
  /// <param name="boisson"></param>
  /// <returns></returns>
  /// <exception cref="BoissonNotFoundException"></exception>
  public Recette FindBoissonRcette ( Boisson boisson )
   {
   if ( boisson == null )
    {
    throw new BoissonNotFoundException( "veuillez saisir le boisson" );
    }
   throw new BoissonNotFoundException( "Boisson sans recette" );
   }


  public Boisson? FindsBoissonById ( int id )
   {
   if ( id == 0 )
    {
    throw new BoissonNotFoundException( "id fausse" );
    }
   return _dbContext.Boissons.Where( b=> b.Id == id ).SingleOrDefault();

   }

  public void UpdateBoisson ( Boisson boisson )
   {
   _dbContext.Boissons.Update( boisson );
   }
  }
 }