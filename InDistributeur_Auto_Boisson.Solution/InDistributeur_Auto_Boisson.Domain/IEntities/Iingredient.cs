using System;
using System.Collections.Generic;
using System.Text;

namespace InDistributeur_Auto_Boisson.Domain.Entities
 {
 public interface Iingredient
  {
  int Id { get; set; }
  string Name { get; set; }
  string Description { get; set; }
  Decimal? prix { get; set; }

  }
 }
