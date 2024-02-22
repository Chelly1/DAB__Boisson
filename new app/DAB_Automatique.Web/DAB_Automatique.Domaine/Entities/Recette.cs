using DAB_Automatique.Domaine.IEntities;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Automatique.Domaine.Entities
 {
 public class Recette : IRecette
  {
  public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  public IDictionary<Ingredient, double> BoissonRecette { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  public ICollection<Ingredient> ingredients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
 }
