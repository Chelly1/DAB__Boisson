using DAB.Domain.IEntities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.Entities
{
    public class Ingredient : IIngredient
    {
        [Key]
        public int Id { get; }

        public string Name { get; set; } = "IngrediantName";

        public string Description { get; set; } = "description";

        public Double Price { get; set; }

        public virtual ICollection<RecetteIngredient> RecetteIngredients { get; set; }

        public Ingredient() { }
        public Ingredient(string name, string description, double price, ICollection<RecetteIngredient> recetteIngredients)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.RecetteIngredients = recetteIngredients;
        }


        //public IList<RecetteIngredient> recetteIngredients { get; set; }



        //public  IList<> RecettesIngrediant { get; set; }
    }
}
