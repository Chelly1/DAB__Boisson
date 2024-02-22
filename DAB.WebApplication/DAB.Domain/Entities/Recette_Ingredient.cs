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
  public int Id_Recette_Ingrediant { get; set; }

  public virtual Recette Recette { get; set; }
  public int? Recette_Id { get; set; }

  public virtual Ingredient Ingredient { get; set; }
  public int Ingredient_Id { get; set; }

  public double Dose { get; set; }
  }

 }
