using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities {

 public interface IBoisson
  { 
  int Id { get; }
   string Name { get; }
   string Description { get; set; }

    Recette Recette { get; set; }
  int? RecetteId { get; set; }



  }
 }
