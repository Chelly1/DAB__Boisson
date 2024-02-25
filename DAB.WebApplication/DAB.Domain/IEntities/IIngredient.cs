using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities
 {
 public interface IIngredient
  {
  int Id { get; }

  string Name { get; }

  string Description { get; }

  Double Price { get; set; }

  //IList<Recette> Recettes { get; }

   ICollection<RecetteIngredient> RecetteIngredients { get; set; }

 
  }
 }
