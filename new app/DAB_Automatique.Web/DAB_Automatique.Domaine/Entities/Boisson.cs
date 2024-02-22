using DAB_Automatique.Domaine.Ientities;
using DAB_Automatique.Domaine.IEntities;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_Automatique.Domaine.Entities
 {
 public class Boisson : Iboisson
  {
  public int Id { get; }

  public string Name { get; set; } = "";


  public virtual Recette Recette { get; set; }

  public string Description { get; set; }

  public int BoissonStock { get; set; }
  public Boisson () { }

  public Boisson ( int _id, string _name, string _description, Recette _recette, int _stock )
   {
   this.Id = _id;
   this.Name = _name;
   this.Description = _description;
   this.Recette = _recette;
   }

  
  }

 }