using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Automatique.Domaine.Ientities
 {
 public interface IIngredient
  {
  int Id { get; }
  string Name { get; }
  string Description { get; }
  Decimal? Price { get; set; }
  }
 }
