using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.IEntities
 {
 internal interface IIngredient
  {
  int Id { get; }
  string Name { get; }
  string Description { get; }
  Decimal? Price { get; set; }
  }
 }
