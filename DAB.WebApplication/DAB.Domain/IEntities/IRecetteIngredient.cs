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
  int Id { get; set; }

  Recette Recette { get; set; }
  int RecetteId { get; set; }

  Ingredient Ingredient { get; set; }
  int IngredientId { get; set; }

  double Dose { get; set; }
  string Unite { get; set; }


  }
 }
