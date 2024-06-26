using DAB.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace DAB.Web.Models
{
    public class RecetteIngredientModele
    {

        public RecetteViewModele RecetteViewModele { get; set; }

        //  public virtual IngredientViewModele IngredientViewModele { get; set; }

        public int RecetteId { get; set; }
        public int IngredientId { get; set; }
        public string Unite { get; set; }
        public double Quantity { get; set; }


    }
}
