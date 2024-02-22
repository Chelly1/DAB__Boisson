using DAB_Automatique.Domaine.Ientities;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Automatique.Domaine.Entities
 {
 public class Ingredient :IIngredient
  {
  //[Key]
  public int Id { get; }

  public string Name { get; set; }

  public string Description { get; set; }

  public decimal? Price { get; set; }
 
  }
 }
 
