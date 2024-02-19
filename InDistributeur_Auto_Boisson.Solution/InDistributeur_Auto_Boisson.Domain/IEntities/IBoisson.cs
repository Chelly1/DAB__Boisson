using System;
using System.Collections.Generic;
using System.Text;

namespace InDistributeur_Auto_Boisson.Domain.Entities
 {
 internal interface IBoisson
  {
   string Name { get; }
  string Destriction { get; set; }
  ICollection<Ingredient> Iingredients { get; set; }


  }
 }
