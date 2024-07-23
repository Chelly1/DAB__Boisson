using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;

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
        public string Unit { get; set; } = "";

       public IngredientViewModele()
        { }
        public IngredientViewModele(string name, string description, double price, string unit )
        {
            this.Name = name;
            Description = description;
            Price = price;
            Unit = unit;
        }
    }
 }
