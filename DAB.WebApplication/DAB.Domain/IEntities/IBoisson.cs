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
  public string Name { get; }
  public string Description { get; set; }

 public   Recette Recette { get; set; }

  }
 }
