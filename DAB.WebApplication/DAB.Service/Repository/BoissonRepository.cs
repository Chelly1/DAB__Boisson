using DAB.Data;
using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;

using Microsoft.EntityFrameworkCore;

namespace DAB.Service.Repository
 {
 public class BoissonRepository : IBoissonRepo
  {
  private readonly DabDbContext _dbContext;

  public BoissonRepository ( DabDbContext dbContext )
   {
   this._dbContext = dbContext;
   }
  /// <summary>
  /// Ajout boisson à la machine
  /// </summary>
  /// <param name="boisson"></param>
  /// <exception cref="NotImplementedException"></exception>
  public void AddBoisson ( Boisson boisson )
   {
   if ( boisson == null )
    { throw new NotFoundException(""); }
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
   
     boisson.Boisson_Stock = +stock;
    }
   }

  /// <summary>
  /// Calcul Boissons pris du boisson
  /// </summary>
  /// <param name="boisson"></param>
  /// <returns></returns>
  /// <exception cref="BoissonNotFoundException"></exception>
  public Double CalculBoissonPrix ( Boisson boisson )
   {
   Double _Pris = 0;

   if ( boisson == null )
    {
    throw new NotFoundException( "Boisson not found" );
    }
   else
    {
    List<Ingredient> ingredientsList = FindBoissantIngredients(boisson).ToList() ;

    if ( ingredientsList == null )
     {
     throw new NotFoundException( "erreur boissan  ingridient" );
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
  /// <summary>
  /// return all boisson
  /// </summary>
  /// <returns></returns>
  /// <exception cref="BoissonNotFoundException"></exception>
  public ICollection<Boisson> FindAllBoisson ()

   {
   ICollection<Boisson> boissonsList= _dbContext.Boissons.Include(r=>r.Recette).ToList() ;

   if ( boissonsList == null )
    {
    throw new NotFoundException( "yooooooooo hneeeeeeee" );
    }
   else
    {
    return boissonsList.ToList();
    }
   }

  public ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson )
   {
   if ( boisson == null ) { throw new NotFoundException( "boisson vide" ); }

   List<Ingredient >_ingredientLists = new List<Ingredient>();

   if ( boisson.Recette != null )
    {
    Recette recette = boisson.Recette;

    List<RecetteIngredient> recetteIngredients = _dbContext.RecetteIngredients.Where(r=>r.RecetteId== recette.Id).ToList();
    if ( recetteIngredients == null ) { throw new NotFoundException( "ingrediant error" ); }
    else
     {
     foreach ( var ingred in recetteIngredients )
      {
      _ingredientLists.Add( ingred.Ingredient );
      }
     }
    }
   return _ingredientLists.ToList();
   }

  //todo:  boisson, by id

  /// <summary>
  /// Find boisson by name
  /// </summary>
  /// <param name="name">boisson name</param>
  /// <returns></returns>
  /// <exception cref="NotFoundException"></exception>
  public Boisson FindBoissonByName ( string name )
   {
   if ( name == null )
    {
    throw new NotFoundException( "veeuillez ecrire le nom du boisson demandé" );
    }
   else
    {
    return _dbContext.Boissons.Where( b => b.Name.Equals( name ) ).FirstOrDefault() ?? throw new NotFoundException( "boisson not found" );
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
    throw new NotFoundException( "veuillez saisir le boisson" );
    }
   throw new NotFoundException( "Boisson sans recette" );
   }


  public Boisson? FindsBoissonById ( int id )
   {
   if ( id == 0 )
    {
    throw new NotFoundException( "id fausse" );
    }
   return _dbContext.Boissons.Where( b => b.Id == id ).SingleOrDefault();
   }


  public void UpdateBoisson ( Boisson boisson )
   {
   _dbContext.Boissons.Update( boisson );
   }
  }
 }