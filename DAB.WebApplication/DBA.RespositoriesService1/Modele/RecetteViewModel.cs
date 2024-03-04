using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.RespositoriesService1.Modele
 {
 public class RecetteViewModel
  {
  [ReadOnly( true )]
  //[Required]
  public string Name { get; set; }

  public string Description { get; set; }

  public ICollection<Ingredient> ingredients { get; set; }
  public RecetteViewModel () { }

  public RecetteViewModel ( string name, string description, ICollection<Ingredient> ingrediantList ) { }

  
  
  
  }
 }
