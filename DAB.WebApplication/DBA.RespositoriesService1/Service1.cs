using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;

using DBA.RespositoriesService1.Modele;

namespace DBA.RespositoriesService1
 {
 public class Service1 : Iservice1
  {

  IBoissonRepo _boissonRepo;
  IRecetteRepository _recetteRepository;
  IIngredientRepository _ingredientRepository;
  IRecetteIngrediantRepository  _recetteIngrediantRepository;


  ///// <summary>
  ///// constructeur
  ///// </summary>
  ///// <param name="boissonRepo"></param>
  ///// <param name="recetteRepository"></param>
  ///// <param name="ingrediantRepo"></param>

  public Service1 ( IBoissonRepo boissonRepo, IRecetteRepository recetteRepository, IIngredientRepository ingrediantRepo, IRecetteIngrediantRepository recetteIngrediantRepository )
   {
   this._boissonRepo = boissonRepo;
   this._recetteRepository = recetteRepository;
   this._ingredientRepository = ingrediantRepo;
   this._recetteIngrediantRepository = _recetteIngrediantRepository;
   }

  /// <summary>
  /// Ajout du stock au boisson
  /// </summary>
  /// <param name="boissonViewModele"></param>
  /// <param name="stock"></param>
  public void AddBoissonstock ( BoissonViewModel boissonViewModele, int stock )
   {
   Boisson boisson = Map_BoissonViewModel_ToBoisson(boissonViewModele);
   boisson.Boisson_Stock = +stock;
   _boissonRepo.UpdateBoisson( boisson );
   }


  public void AddIngredient ( IngrediantViewModelee ingredientViewModel )
   {
   Ingredient ingredient = Map_IngrediantViewModele_ToIngrediant(ingredientViewModel);
   _ingredientRepository.updateIngrediant( ingredient );
   }

  public void AddNewRecette ( RecetteViewModelee recetteViewModel )
   {
   if ( recetteViewModel == null )
    {
    throw new Exception();
    }

   Recette recette = Map_RecetteViewModeleToReecette( recetteViewModel );

   _recetteRepository.AddNewRecette( recette );
   }

  public void AddBoisson ( BoissonViewModel boissonViewModele )
   {
   if ( boissonViewModele == null )
    {

    }
   }

  public double CalculBoissonPrix ( BoissonViewModel boissonViewModele )
   {
   throw new NotImplementedException();
   }

  public void DeleteRecette ( RecetteViewModelee recetteViewModel )
   {
   throw new NotImplementedException();
   }

  public ICollection<IngrediantViewModelee> FindBoissantIngredients ( BoissonViewModel boissonViewModele )
   {
   throw new NotImplementedException();
   }

  public BoissonViewModel FindBoissonByName ( string name )
   {
   throw new NotImplementedException();
   }

  public RecetteViewModelee FindBoissonRcette ( BoissonViewModel boissonViewModele )
   {
   throw new NotImplementedException();
   }

  public IngrediantViewModelee FindIngredientById ( int id )
   {
   throw new NotImplementedException();
   }

  public RecetteViewModelee FindRecetteById ( int id )
   {
   throw new NotImplementedException();
   }

  public RecetteViewModelee FindRecetteByName ( string name )
   {
   throw new NotImplementedException();
   }

  public BoissonViewModel Find_BoissonByRecette ( RecetteViewModelee recetteViewModel )
   {
   throw new NotImplementedException();
   }

  public BoissonViewModel FinfBoissonById ( int id )
   {
   throw new NotImplementedException();
   }

  public List<IngrediantViewModelee> GetAllIngrediant ()
   {
   throw new NotImplementedException();
   }

  public ICollection<IngrediantViewModelee> GetAllIngrediantViewModel ()
   {
   throw new NotImplementedException();
   }

  public decimal GetIngredientCost ( IngrediantViewModelee ingredientViewModel )
   {
   throw new NotImplementedException();
   }

  public ICollection<IngrediantViewModelee> IngrediantByRecette ( RecetteViewModelee recetteViewModel )
   {
   throw new NotImplementedException();
   }

  public ICollection<RecetteViewModelee> RecetteIngrediant ( IngrediantViewModelee ingredientViewModel )
   {
   throw new NotImplementedException();
   }

  public void SetIngredientCost ( Ingredient ingredient, decimal cost )
   {
   throw new NotImplementedException();
   }

  public void UpdateBoisson ( BoissonViewModel boissonViewModele )
   {
   throw new NotImplementedException();
   }

  public IngrediantViewModelee Map_IngridiantToIngrediantViewModel ( Ingredient ingredient )
   {
   throw new NotImplementedException();
   }

  public Ingredient Map_IngrediantViewModele_ToIngrediant ( IngrediantViewModelee ingrediantViewModele )
   {
   throw new NotImplementedException();
   }

  public Boisson Map_BoissonViewModel_ToBoisson ( BoissonViewModel BoissonViewModele )
   {
   throw new NotImplementedException();
   }



  /// <summary>
  /// Mazp boisson to boissonView modele 
  /// </summary>
  /// <param name="boisson">input</param>
  /// <returns></returns>
  public BoissonViewModel Map_BoissonToBoissonViewModel ( Boisson boisson )
   {
   if ( boisson == null )
    {
    throw new DllNotFoundException( "boisson null" );
    }

   BoissonViewModel boissonViewModeleResult = new BoissonViewModel
    {
    Name= boisson.Name?? "",
    Description= boisson.Description??"",
    stock = boisson.Boisson_Stock,
    RecetteViewModel = new RecetteViewModelee
     {
     Name= boisson.Recette.Name,
     Description= boisson.Recette.Description,
     ingredients = _ingredientRepository.FindBoissantIngredients(boisson).ToList()
     }
    };
   if ( boissonViewModeleResult == null )
    {
    throw new Exception( "boissonViewModel map error" );
    }
   return boissonViewModeleResult;
   }



  //Map les donnes de recetteViewModele dans Recette
  public Recette Map_RecetteViewModeleToReecette ( RecetteViewModelee recetteViewModel )
   {
   List<RecetteIngredient>  ingrediantByRecette = new List<RecetteIngredient>();
   if ( recetteViewModel == null )
    {
    throw new ArgumentNullException();
    }
   else
    {
    List<Ingredient> ingredients = recetteViewModel.ingredients.ToList ();
    List<RecetteIngredient> recetteIngredients = new List<RecetteIngredient>();
    if ( ingredients != null )
     {
     for ( int i = 0; i < ingredients.Count; i++ )
      {
      ingrediantByRecette = _recetteIngrediantRepository.GetRecetteIngrediantsByIngrediant( ingredients[i] ).ToList();
      }
     }
    if ( ingrediantByRecette == null )
     {
     throw new DllNotFoundException( "list ingrediant de cette recette est null" );
     }
    else
     {
     Recette recette = new Recette
      (
      recetteViewModel.Name,
      recetteViewModel.Description,
     ingrediantByRecette.ToList()
      );
     return recette;
     }
    }
   }

  /// <summary>
  /// Map les donnees de recette dans  recette viewModele
  /// </summary>
  /// <param name="recette"></param>
  /// <returns></returns>
  /// <exception cref="NotImplementedException"></exception>
  public RecetteViewModelee Map_Recette_ToRecetteViewModele ( Recette recette )
   {
   RecetteViewModelee recetteViewModele =  new RecetteViewModelee() ;
   List <Ingredient> ingredients = new List<Ingredient> ();
   List<RecetteIngredient> recetteIngredients = recette.RecetteIngredients.ToList ();

   if ( recetteIngredients == null )
    { throw new ArgumentNullException( "recette ingrediant nill" ); }
   foreach ( var rcing in recetteIngredients )
    {
    if ( rcing.Ingredient != null )
     {
     ingredients.Add( rcing.Ingredient );
     }
    recetteViewModele.Name = recette.Name;
    recetteViewModele.Description = recette.Description;
    recetteViewModele.ingredients = ingredients;
    }
   if ( recetteViewModele == null )
    {
    throw new Exception( "recette view modele vide" );
    }
   return recetteViewModele;
   }

  public List<Boisson> getAllBoissson ()
   {
   if ( _boissonRepo.FindAllBoisson() == null )
    {
    throw new NotFoundException( "absence de boisson" );
    }
   return _boissonRepo.FindAllBoisson().ToList();
   }


  }
 }