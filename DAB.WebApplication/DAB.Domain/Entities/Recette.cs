using DAB.Domain.IEntities;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.Entities
{
    public class Recette : IRecette
    {

        [Key]
        public int Id { get; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";


        public virtual ICollection<RecetteIngredient> RecetteIngredients { get; set; }


        public virtual Boisson Boisson { get; set; }
        public string Instructions { get; set; }

        public Recette() { }

        public Recette(string _name, string _description, ICollection<RecetteIngredient> recetteIngrediant)
        {
            this.Name = _name;
            this.Description = _description;
            this.RecetteIngredients = recetteIngrediant;
         }


    }
}
