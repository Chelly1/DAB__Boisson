using DAB.Domain.IEntities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Domain.Entities
 {
 public class Boisson : IBoisson
  {

  public int Id { get; }

  public string Name { get; set; } = "";


  public virtual Recette Recette { get; set; }
  int? RecetteId { get; set; }

  public string Description { get; set; }

  public int BoissonStock { get; set; }

  int? IBoisson.RecetteId { get; set; }

  public Boisson () { }

  public Boisson ( int _id, string _name, string _description, Recette _recette, int _stock )
   {
   this.Id= _id;
   this.Name = _name;
   this.Description = _description;
   this.Recette = _recette;
   this.BoissonStock = _stock;
   }

  }
 }
