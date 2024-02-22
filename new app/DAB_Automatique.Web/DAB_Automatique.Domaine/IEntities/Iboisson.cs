using DAB_Automatique.Domaine.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Automatique.Domaine.IEntities
 {
 public interface Iboisson
  {
  int Id { get; }
   string Name { get; }
   string Description { get; set; }
  Recette Recette { get; set; }

 }
 }
