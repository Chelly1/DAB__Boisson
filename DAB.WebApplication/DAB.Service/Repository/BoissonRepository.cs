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
    if ( stock != null && stock > 0 )
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

   {
   ICollection<Boisson> boissonsList= _dbContext.Boissons.Include(r=>r.Recette).ToList() ;

   if ( boissonsList == null )
    {
    throw new BoissonNotFoundException( "yooooooooo hneeeeeeee" );
    }
   else
    {
    return boissonsList.ToList();
    }
   }
  //todo:  boisson, by id
  public ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson )
   {
   List<Ingredient> _IngredientsResults = new List<Ingredient>();
   if ( boisson == null )
    {
    throw new BoissonNotFoundException( "booisson non trouver" );
    }

    return _dbContext.RecetteIngredients
    .Where(ri=> ri.Recette != null && ri.Recette.Boisson != null && ri.Recette!.Boisson!.Id == boisson.Id)
    .Select(ri=> ri.Ingredient).ToList();
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
    return _dbContext.Boissons.Where( b => b.Id == id ).SingleOrDefault();

    }

   public void UpdateBoisson ( Boisson boisson )
    {
    _dbContext.Boissons.Update( boisson );
    }
   }
  }