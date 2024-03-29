﻿using AutoMapper;

using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;
using DAB.Web.Models;

namespace DAB.Web.service
 {
 public class Service : Iservice
  {
  #region declaration
  private readonly IMapper _mapper;

  private readonly IBoissonRepo _boissonRepo;
  private readonly IRecetteRepository _recetteRepository;
  private readonly IIngredientRepository _ingredientRepository;
  private readonly IRecetteIngrediantRepository  _recetteIngrediantRepository;

  public Service ( IMapper mapper, IBoissonRepo boissonRepo, IRecetteRepository recetteRepository,
   IIngredientRepository ingredientRepository, IRecetteIngrediantRepository recetteIngrediantRepository )
   {
   _mapper = mapper;
   _boissonRepo = boissonRepo;
   _recetteRepository = recetteRepository;
   _ingredientRepository = ingredientRepository;
   _recetteIngrediantRepository = recetteIngrediantRepository;
   }
  #endregion 

  /// <summary>
  /// ajout nouveau Boisson
  /// </summary>
  public void AddBoisson ( Boisson boisson )
   {

   var mappedBoisson = _mapper.Map<Boisson>(boisson);
   _boissonRepo.AddBoisson( mappedBoisson );
   }

  public void AddBoissonstock ( Boisson boisson, int stock )
   {
   if ( boisson == null )
    {
    throw new ArgumentNullException( " selectionner boisson " );
    }
   else
    {
    boisson.Boisson_Stock += stock;
    _boissonRepo.UpdateBoisson( boisson );
    }
   }

  public void AddIngredient ( Ingredient ingredient )
   {
   if ( ingredient == null )
    {
    throw new Exception( "Ajouter un bon ingredient" );
    }
   else
    {
    _ingredientRepository.AddIngredient( ingredient );
    }
   }

  public void AddNewRecette ( Recette recette )
   {
   if ( recette == null )
    {
    throw new Exception( "  pas dereccette à ajouter  " );
    }
   else
    {
    _recetteRepository.AddNewRecette( recette );
    }
   }

  public double CalculBoissonPrix ( Boisson boisson )
   {
   double price = 0;
   Recette recette = boisson.Recette;
   List<Ingredient> ingredients=  FindIngredientByRecette(recette);

   if ( ingredients == null )
    { return price; }
   else
    {
    foreach ( var ing in ingredients )
     {
     price += ing.Price;
     }
    }
   return price;
   }

  public void DeleteRecette ( Recette recette )
   {
   _recetteRepository.DeleteRecette( recette );
   }

  public ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson )
   {
   List<Ingredient> ingredients;
   if ( boisson == null )
    {
    throw new NotFoundException( "boisson no specifier" );
    }
   else
    {
    ingredients = FindIngredientByRecette( boisson.Recette );
    }
   return ingredients;
   }

  public Boisson FindBoissonByName ( string name )
   {
   return _boissonRepo.FindBoissonByName( name );
   }

  public Recette FindBoissonRcette ( Boisson boisson )
   {
   throw new NotImplementedException();
   }

  public Ingredient FindIngredientById ( int id )
   {
   return _ingredientRepository.FindIngredientById( id );
   }

  public List<Ingredient> FindIngredientByRecette ( Recette recette )
   {
   List <Ingredient> ingredients = new List<Ingredient>();
   if ( recette == null )
    {
    throw new NotFoundException( "recette not specifier" );
    }
   else
    {
    foreach ( var ing in recette.RecetteIngredients )
     {
     ingredients.Add( ing.Ingredient );
     }
    if ( ingredients.Count == 0 )
     {
     throw new Exception( "ingredient absent" );
     }

    return ingredients;
    }
   }

   public Recette FindRecetteById ( int id )
    {
   return _recetteRepository.FindRecetteById( id );
    }

   public ICollection<Recette> FindRecetteByIngrediant ( Ingredient ingredient )
    {
    List<RecetteIngredient> recetteIngredients = _recetteIngrediantRepository.GetRecetteIngrediantsByIngrediant( ingredient );

   List<Recette> recettes = new List<Recette>();
   foreach (var rI in recetteIngredients )
    {
    if(rI != null && rI.Recette != null )
     {
     recettes.Add( rI.Recette );
     }

    }
   return recettes;
    }

   public Recette FindRecetteByName ( string name )
    {
   return _recetteRepository.FindRecetteByName( name );
    }

   public ICollection<RecetteIngredient> FindRecetteIngrediantByIngrediant ( Ingredient ingredient )
    {
    return _recetteIngrediantRepository.GetRecetteIngrediantsByIngrediant(ingredient );
    }

   public Boisson Find_BoissonByRecette ( Recette recette )
    {
   if ( recette == null )
    {
    throw new NotFoundException( "recette not speciphied" );
    }
   else
    {
    return _recetteRepository.Find_BoissonByRecette( recette );
    }

    }

   public Boisson FinfBoissonById ( int id )
    {
   return _boissonRepo.FindsBoissonById( id );
    }

   public ICollection<Boisson> getAllBoisson ()
    {
   return _boissonRepo.FindAllBoisson();
    }


   public List<Boisson> getAllBoissson ()
    {
   return _boissonRepo.FindAllBoisson().ToList();
    }

   public ICollection<Ingredient> GetAllIngrediant ()
    {
   return _ingredientRepository.GetAllIngrediant();
    }

   public double GetIngredientCost ( Ingredient ingredient )
    {
    if(ingredient == null )
    {
    throw new NotFoundException( "ingredient not found" );
    }
    else
    {
    return ingredient.Price;
    }

    }

  public ICollection<Ingredient> IngrediantByRecette ( Recette recette )
   {
   return FindIngredientByRecette( recette );
   }

  public void SetIngredientCost ( Ingredient ingredient, double cost )
    {
   ingredient.Price = cost;
   _ingredientRepository.updateIngrediant ( ingredient );
    }

   public void UpdateBoisson ( Boisson boisson )
    {
   if(boisson == null )
    {
    throw new NotFoundException( "boisson not found" );
    }
   _boissonRepo.UpdateBoisson( boisson );
    }
   }
  }
