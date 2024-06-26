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
        public string Instructions { get; set; }

        public ICollection<RecetteIngredient> recetteIngredients { get; set; }

        public List<IngredientViewModele> Ingredients { get; set; }
        public List<int> SelectedIngredientIds { get; set; }
        public Boisson BoissonOfRecette { get; set; }

    }
}
