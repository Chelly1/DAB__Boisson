using System.ComponentModel.DataAnnotations;

namespace DAB.Web.Models
 {
 public class IngredientViewModele
  {
        [StringLength(100)]
        [Display(Name ="Ingrediant name")]
  [Required]
  public string Name { get; set; }

  public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public string Unit { get; set; }
        
        public ICollection<RecetteIngredientModele> recetteIngredientModeles { get; set;}

    }
 }
