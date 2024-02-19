using DAB.Domain.IEntities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.Entities
 {
 public class Ingredient : IIngredient
  {
  [Key]
  public int Id { get; }

  public string Name { get; set; }

  public string Description { get; set; }

  public decimal? Price { get; set; }
  }
 }
