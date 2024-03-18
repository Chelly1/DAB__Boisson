using DAB.Data;
using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;

namespace DAB.Service.Repository
 {

 public class IngredientRepository : IIngredientRepository
  {

  private readonly DabDbContext _dbContext;

  public IngredientRepository ( DabDbContext dbContext )
   {
   this._dbContext = dbContext;
   }
  public void AddIngredient ( Ingredient ingredient )
   {
   if ( ingredient != null )
    _dbContext.Ingredients.Add( ingredient );

   }
  /// <summary>
  /// list des ingrediant for boisson
  /// </summary>
  /// <param name="boisson"></param>
  /// <returns></returns>
  /// <exception cref="NotFoundException"></exception>
  public ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson )
   {
   List<RecetteIngredient> recetteIngredients;
   List<Ingredient> ingredientsResults = new List<Ingredient>();

   if ( boisson == null )
    {
    throw new NotFoundException( "booisson non trouver", (long) boisson.Id );
    }
   else
    {
    Recette boissonRecette = boisson.Recette;

    if ( boissonRecette == null )
     { throw new NotFoundException( "recette null" ); }
    else
     {
     recetteIngredients = _dbContext.RecetteIngredients.Where( r => r.Recette.Id == boissonRecette.Id ).ToList();
     }

    if ( recetteIngredients == null )
     {
     throw new NotFoundException( "ingrediant recette not declared" );
     }
    else
     {
     foreach ( var o in recetteIngredients )
      {
      ingredientsResults.Add( o.Ingredient );
      }
     if ( boissonRecette == null )
      {
      throw new NotFoundException( "Ingrediants absent" );
      }
     }
    }
   return ingredientsResults.ToList();
   }


  /// <summary>
  /// return Ingrediant by Id 
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public Ingredient FindIngredientById ( int id )
   {
   if ( _dbContext.Ingredients.Where(i=>i.Id==id).FirstOrDefault() == null )
    {
    throw new NotFoundException( "ingrediant not found" );
    }

   return _dbContext.Ingredients.Where(i=>i.Id==id ).FirstOrDefault();
   }

  public ICollection<Ingredient> FindIngredizantByRecetteIngrediant ( RecetteIngredient recetteIngredient )
   {
   throw new NotImplementedException();
   }

  public ICollection<RecetteIngredient> FindRecetteIngrediantByRecette ( Recette recette )
   {
   if ( recette == null ) { throw new NotFoundException( "recet null" ); }
   return _dbContext.RecetteIngredients.Where( ri => ri.Recette.Id == recette.Id ).ToList();
   }

  /// <summary>
  /// Return all ingrediant 
  /// </summary>
  /// <returns></returns>
  /// <exception cref="System.Exception"></exception>
  public List<Ingredient> GetAllIngrediant ()
   {
   if ( _dbContext.Ingredients == null )
    {
    throw new System.Exception( "list ingrediant vide" );
    }
   else
    {
    return _dbContext.Ingredients.ToList();
    }
   }

  public decimal GetIngredientCost ( Ingredient ingredient )
   {
   return (decimal) ingredient.Price;
   }
  /// <summary>
  /// return list de recette pour chaque ingrediant
  /// </summary>
  /// <param name="ingredient"></param>
  /// <returns></returns>
  /// <exception cref="NotFoundException"></exception>
  public ICollection<Recette> RecetteIngrediant ( Ingredient ingredient )
   {
   List<Recette> recettesList = new List<Recette>();

   List<RecetteIngredient> _recetteIngrediants= _dbContext.RecetteIngredients.Where(i=>i.IngredientId == ingredient.Id).ToList();
   if ( ReferenceEquals == null )
    {
    throw new NotFoundException( "pas de recette pour cet ingrediant" );
    }
   else
    {
    foreach ( var _rd in _recetteIngrediants.ToList() )
     {
     recettesList.Add( _rd.Recette );
     }
    }
   return recettesList.ToList();
   }
  /// <summary>
  /// set cost of ingrediant
  /// </summary>
  /// <param name="ingredient"></param>
  /// <param name="cost"></param>
  /// <exception cref="NotFoundException"></exception>
  public void SetIngredientCost ( Ingredient ingredient, double cost )
   {
   if ( ingredient == null )
    {
    throw new NotFoundException( "ingrediant not found", (long) ingredient.Id );
    }
   else
    {
    ingredient.Price = cost;
    _dbContext.Update( ingredient );
    }
   }

  public void updateIngrediant ( Ingredient ingredient )
   {
   if ( ingredient == null )
    {
    throw new NotFoundException( "" );
    }
   else
    {


    _dbContext.Ingredients.Update( ingredient );
    }
   }



  Ingredient IIngredientRepository.GetIngredientByName ( string name )
   {

   if ( name == null )
    {
    throw new NotFoundException( "ingrediant name absent" );
    }
   else
    {
    if ( _dbContext.Ingredients.Where( i => i.Name.Equals( name ) ).FirstOrDefault() == null )
     {
     throw new NotFoundException( "Ingredient pas renseignee" );
     }
    return _dbContext.Ingredients.Where( i => i.Name.Equals( name ) ).FirstOrDefault();


    }
   }



   }
 }