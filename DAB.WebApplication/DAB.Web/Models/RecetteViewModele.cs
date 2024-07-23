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
        = new List<RecetteIngredient>();

        public List<IngredientViewModele> Ingredients { get; set; }
        = new List<IngredientViewModele>();
        public int[] SelectedIngredientIds { get; set; }
        public Boisson BoissonOfRecette { get; set; }
        public RecetteViewModele(string name, string description, string instruction)
        {
            this.Name = name;
            this.Description = description;
            this.Instructions = instruction;
        }
        public RecetteViewModele()
        {
                
        }

    }
}
