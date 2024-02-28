using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.IRepository
 {
 public interface IIngredientRepository
  {

  ICollection<Ingredient> GetAll();
  void AddIngredient ( Ingredient ingredient );

  Ingredient FindIngredientById ( int id );

  List<Ingredient> GetAllIngrediant ();

  Decimal GetIngredientCost (Ingredient ingredient);

  void SEtIngredientCost(Ingredient ingredient,decimal cost);

  ICollection<Recette> RecetteIngrediant(Ingredient ingredient );


  }
 }
