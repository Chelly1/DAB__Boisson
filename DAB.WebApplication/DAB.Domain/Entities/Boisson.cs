using DAB.Domain.IEntities;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
  [Key]
  public int Id { get; }

  public string Name { get; set; } = "";

  public int RecetteId { get; set; }
  
  public virtual Recette? Recette { get; set; }


  public string Description { get; set; }

  public int? Boisson_Stock { get; set; }

  public Boisson () { }

  public Boisson ( int _id, string _name, string _description, Recette _recette, int boissonstock )
   {
   this.Id = _id;
   this.Name = _name;
   this.Description = _description;
   this.Recette = _recette;
   this.Boisson_Stock = boissonstock;
   }

  }
 }
