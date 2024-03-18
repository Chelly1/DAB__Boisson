using DAB.Domain.Entities;

using System.ComponentModel.DataAnnotations;

namespace DAB.Web.Models
 {
 public class BoissonViewModele
  {

  [Display(Name ="Nom du Boisson ")]
  public string Name { get; set; } = "";

  [Display(Name = "la recette du boisson")]

  public    string RecetteName { get; set; }

  public string Description { get; set; }

  public int? Boisson_Stock { get; set; }

  public RecetteViewModele RecetteViewModele { get; set;}
  }
 }
