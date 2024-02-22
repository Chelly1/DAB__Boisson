using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities
 {
 public interface IRecette
  { 
  int Id { get; }
  string Name { get; set; }
  IList<Ingredient> Ingredients { get; set; }

 //ICollection<RecetteIngredient> recetteIngredients { get; set; }


  }
 }
