using System;
using System.Collections.Generic;
using System.Text;

namespace InDistributeur_Auto_Boisson.Domain.Entities
 {
 internal class Boisson : IBoisson
  {
  public string Name => throw new NotImplementedException();

  public string Destriction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
 
  public ICollection<Ingredient> Iingredients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
 }
