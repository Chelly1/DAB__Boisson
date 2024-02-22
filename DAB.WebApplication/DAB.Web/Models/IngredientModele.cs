using System.ComponentModel.DataAnnotations;

namespace DAB.Web.Models
 {
 public class IngredientModele
  {
  [Display(Name ="Ingrediant name")]
  [Required]
  public string Name { get; set; }

  public string Description { get; set; }

  public decimal? Price { get; set; }
  }
 }
