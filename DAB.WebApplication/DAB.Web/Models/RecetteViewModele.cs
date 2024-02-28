using DAB.Domain.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAB.Web.Models
 {
 public class RecetteViewModel
  {
  [ReadOnly(true)]
  [Required]
  public string Name { get; set; }

  public string Description { get; set; }
  ICollection<Ingredient> ingredients { get; set; }

  public Dictionary<string, double> BoissonRecette { get; set; }
  }
 }
