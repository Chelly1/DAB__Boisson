using DAB.Domain.IEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.Entities
 {
 public class RecetteIngredient : IRecetteIngredient
  {

  public RecetteIngredient ()
   {
   }
   public RecetteIngredient ( int id, int recetteId, Recette recette, int ingredientId, Ingredient ingredient, string unite, double dose )
   {
   Id = id;
   RecetteId = recetteId;
   Recette = recette;
   IngredientId = ingredientId;
   Ingredient = ingredient;
   Unite = unite;
   Dose = dose;
   }

  public int Id { get; set; }
   public int RecetteId { get; set; }
   public virtual Recette Recette { get; set; }
   public int IngredientId { get; set; }
   public virtual Ingredient Ingredient { get; set; }
   public string Unite { get; set ; }
   public double Dose { get; set; }
  }
 
 }
