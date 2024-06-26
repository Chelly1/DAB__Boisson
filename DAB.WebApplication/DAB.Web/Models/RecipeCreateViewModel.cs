



using System.Web;
using System.Web.Mvc;

namespace DAB.Web.Models
{
    public class RecipeCreateViewModel
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string Description { get; set; }
        public List<IngredientViewModele> Ingredients { get; set; }
        public List<int> SelectedIngredientIds { get; set; }
    }
}
