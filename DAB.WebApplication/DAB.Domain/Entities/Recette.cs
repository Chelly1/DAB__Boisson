using DAB.Domain.IEntities;

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
  public string Name { get; set; }

  public string Description { get; set; }

  [Key]
  public int Id { get; }  

  public IList<Ingredient> Ingredients { get;set; }


  //public ICollection<RecetteIngredient> recetteIngredients { get;set;}

  public Recette () { }

  public Recette ( string _name, string _description )
   {
   this.Name = _name;
   this.Description = _description;
   }


  }
 }
