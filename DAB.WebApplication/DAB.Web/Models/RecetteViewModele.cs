using DAB.Domain.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAB.Web.Models
 {
 public class RecetteViewModele
  {
  [ReadOnly(true)]
  [Required]
  public string Name { get; set; }

  public string Description { get; set; }

  ICollection<string> IngredientsName { get; set; }

  public Boisson BoissonOfRecette { get; set; }
  
  }
 }
