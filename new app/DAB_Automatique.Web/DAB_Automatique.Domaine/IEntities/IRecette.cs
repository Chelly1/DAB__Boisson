using DAB_Automatique.Domaine.Entities;
using DAB_Automatique.Domaine.Ientities;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Automatique.Domaine.IEntities
 {
 public interface IRecette
  {
  string Name { get; set; }
  IDictionary<Ingredient, double> BoissonRecette { get; set; }

  ICollection<Ingredient> ingredients { get; set; }
  }
 }
