using System.ComponentModel.DataAnnotations;

namespace DAB.Web.Models
 {
 public class IngredientViewModele
  {
  [Display(Name ="Ingrediant name")]
  [Required]
  public string Name { get; set; }

  public string Description { get; set; }

  public double Price { get; set; }
  }
 }
