using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.RespositoriesService1.Modele
 {
 public class IngrediantViewModelee
  {
  [DisplayName( "Ingrediant name" )]

  [Required]
  public string Name { get; set; }

  public string Description { get; set; }
  [Required]
  public double Price { get; set; }
  }
 }
