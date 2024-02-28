using DAB.Domain.Entities;

using DBA.RespositoriesService1.Modele;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.RespositoriesService1
 {
 public interface Iservice1
  {
  #region Boisson

  List<Boisson> getAllBoissson();
  void AddBoisson ( BoissonViewModel boissonViewModele );
  void AddBoissonstock ( BoissonViewModel boissonViewModele, int stock );
  void UpdateBoisson ( BoissonViewModel boissonViewModele );
  BoissonViewModel FinfBoissonById ( int id );
  BoissonViewModel FindBoissonByName ( string name );
  RecetteViewModelee FindBoissonRcette ( BoissonViewModel boissonViewModele );
  Double CalculBoissonPrix ( BoissonViewModel boissonViewModele );
  ICollection<IngrediantViewModelee> FindBoissantIngredients ( BoissonViewModel boissonViewModele );

  #endregion Boisson

  #region Ingrediant

  ICollection<IngrediantViewModelee> GetAllIngrediantViewModel ();
  void AddIngredient ( IngrediantViewModelee ingredientViewModel );
  IngrediantViewModelee FindIngredientById ( int id );
  List<IngrediantViewModelee> GetAllIngrediant ();
  Decimal GetIngredientCost ( IngrediantViewModelee ingredientViewModel );
  void SetIngredientCost ( Ingredient ingredient, decimal cost );
  ICollection<RecetteViewModelee> RecetteIngrediant ( IngrediantViewModelee ingredientViewModel );

  #endregion Ingrediant


  #region  Recette

  void AddNewRecette ( RecetteViewModelee recetteViewModel );

  void DeleteRecette ( RecetteViewModelee recetteViewModel );

  RecetteViewModelee FindRecetteById ( int id );

  RecetteViewModelee FindRecetteByName ( string name );

  BoissonViewModel Find_BoissonByRecette ( RecetteViewModelee recetteViewModel );

  ICollection<IngrediantViewModelee> IngrediantByRecette ( RecetteViewModelee recetteViewModel );

  #endregion

  // Map ingrediant to Ingrediiant modele
  IngrediantViewModelee Map_IngridiantToIngrediantViewModel ( Ingredient ingredient );
  Ingredient Map_IngrediantViewModele_ToIngrediant ( IngrediantViewModelee ingrediantViewModele );


  Boisson Map_BoissonViewModel_ToBoisson ( BoissonViewModel BoissonViewModele );
  BoissonViewModel Map_BoissonToBoissonViewModel ( Boisson boisson );

  Recette Map_RecetteViewModeleToReecette ( RecetteViewModelee recetteViewModel );
  RecetteViewModelee Map_Recette_ToRecetteViewModele ( Recette recette );


  }
 }

