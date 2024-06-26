using DAB.Domain.Entities;
using DAB.Web.Models;



namespace DAB.Web.service
 {
 public interface Iservice
  {
  #region Boisson

 
  ICollection<Boisson> FindAllBoisson ();

  void AddBoisson ( Boisson boisson );

  void AddBoissonstock ( Boisson boisson, int stock );

  void UpdateBoisson ( Boisson boisson );

  Boisson FinfBoissonById ( int id );

  Boisson FindBoissonByName ( string name );


  Double CalculBoissonPrix ( Boisson boisson );

  ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson );

  Boisson Find_BoissonByRecette ( Recette recette );

  #endregion Boisson


  #region Ingrediant

  ICollection<Ingredient> FindAllIngrediant ();

  void AddIngredient ( Ingredient ingredient );

  Ingredient FindIngredientById ( int id );

  double FindIngredientCost ( Ingredient ingredient );

  void SetIngredientCost ( Ingredient ingredient, double cost );

  ICollection<Recette> FindRecetteByIngrediant ( Ingredient ingredient );

        #endregion Ingrediant


        #region  Recette
        List<Recette> FindAllRecette();
  Recette FindBoissonRcette ( Boisson boisson );

  void AddNewRecette ( Recette recette );

  void DeleteRecette ( Recette recette );

  Recette FindRecetteById ( int id );

  Recette FindRecetteByName ( string name );

  List<Ingredient> FindIngredientByRecette(Recette recette );
      


        List<Recette> GetAllRecetteAvecIngredients();

        ICollection<RecetteIngredient> FindRecetteIngrediantByIngrediant ( Ingredient ingredient );
  #endregion




  }
 }
