using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities
 {
 internal interface IRecette
  {
  int  Id { get; }
  string Name { get; }

  string Description { get; set; }

  ICollection<Ingredient> Ingredients { get; set; }
  //Dictionary<Ingredient, decimal> BoissonRecette { get; set; } 

  }
 }
