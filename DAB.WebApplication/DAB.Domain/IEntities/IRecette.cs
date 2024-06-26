using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities
 {
 public interface IRecette
  { 
  int Id { get; }
  string Name { get; set; }
  Boisson Boisson { get; set; }
        public string Instructions { get; set; }

        ICollection<RecetteIngredient> RecetteIngredients { get; set; }
  }
 }
