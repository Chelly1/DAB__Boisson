using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities
 {
 public interface IRecetteIngredient
  {
  int Id_Recette_Ingrediant { get; set; }

  Recette Recette { get; set; }
  int? Recette_Id { get; set; }

  Ingredient Ingredient { get; set; }
  int Ingredient_Id { get; set; }

  double Dose { get; set; }

  }
 }
