using DAB.Domain.Entities;
using DAB.Service.Exception;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.IRepository
 {
 public interface IIngredientRepository
  {


  void AddIngredient ( Ingredient ingredient );

  Ingredient FindIngredientById ( int id );

  List<Ingredient> GetAllIngrediant ();
  void updateIngrediant(Ingredient ingredient );

  Decimal GetIngredientCost (Ingredient ingredient);

  void SetIngredientCost(Ingredient ingredient,double cost);

  ICollection<Recette> RecetteIngrediant(Ingredient ingredient );


  ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson );

  ICollection<RecetteIngredient> FindRecetteIngrediantByRecette ( Recette recette );

  ICollection<Ingredient> FindIngredizantByRecetteIngrediant ( RecetteIngredient recetteIngredient );
  
  Ingredient GetIngredientByName(string name);


   }
  
 }
