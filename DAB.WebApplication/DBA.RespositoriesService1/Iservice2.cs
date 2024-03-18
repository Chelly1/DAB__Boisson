using DAB.Domain.Entities;
using DBA.RespositoriesService1.Modele;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.RespositoriesService1
 {
 internal interface Iservice2
  {

  #region Boisson

  List<Boisson> getAllBoissson ();
  ICollection<BoissonViewModel> getAllBoissonViewModele ();
  void AddBoisson ( BoissonViewModel boissonViewModele );
  void AddBoissonstock ( BoissonViewModel boissonViewModele, int stock );
  void UpdateBoisson ( BoissonViewModel boissonViewModele );
  BoissonViewModel FinfBoissonById ( int id );
  BoissonViewModel FindBoissonByName ( string name );
  RecetteViewModel FindBoissonRcette ( BoissonViewModel boissonViewModele );
  Double CalculBoissonPrix ( BoissonViewModel boissonViewModele );
  ICollection<IngrediantViewModel> FindBoissantIngredients ( BoissonViewModel boissonViewModele );

  #endregion Boisson

  #region Ingrediant

  ICollection<IngrediantViewModel> GetAllIngrediantViewModel ();
  void AddIngredient ( IngrediantViewModel ingredientViewModel );
  IngrediantViewModel FindIngredientById ( int id );
  List<IngrediantViewModel> GetAllIngrediant ();
  Decimal GetIngredientCost ( IngrediantViewModel ingredientViewModel );
  void SetIngredientCost ( Ingredient ingredient, decimal cost );
  ICollection<RecetteViewModel> FindRecetteByIngrediant ( IngrediantViewModel ingredientViewModel );

  #endregion Ingrediant


  #region  Recette

  void AddNewRecette ( RecetteViewModel recetteViewModel );

  void DeleteRecette ( RecetteViewModel recetteViewModel );

  RecetteViewModel FindRecetteById ( int id );

  RecetteViewModel FindRecetteByName ( string name );

  BoissonViewModel Find_BoissonByRecette ( RecetteViewModel recetteViewModel );

  ICollection<IngrediantViewModel> IngrediantByRecette ( RecetteViewModel recetteViewModel );

  #endregion

  // Map ingrediant to Ingrediiant modele
  IngrediantViewModel Map_IngridiantToIngrediantViewModel ( Ingredient ingredient );
  Ingredient Map_IngrediantViewModele_ToIngrediant ( IngrediantViewModel ingrediantViewModele );


  Boisson Map_BoissonViewModel_ToBoisson ( BoissonViewModel BoissonViewModele );
  BoissonViewModel Map_BoissonToBoissonViewModel ( Boisson boisson );

  Recette Map_RecetteViewModeleToReecette ( RecetteViewModel recetteViewModel );
  RecetteViewModel Map_Recette_ToRecetteViewModele ( Recette recette );

  ICollection<IngrediantViewModel> FindIngrediantViewModel ();

  ICollection<RecetteIngredient> FindRecetteIngrediantByIngrediant ( IngrediantViewModel ingrediantViewModel );


  }
 }
