using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA.RespositoriesService1.Modele
 {
 public class BoissonViewModel
  {
  //[Display( Name= "Nom du Boisson " )]
  public string Name { get; set; } = "";

  [DisplayName( "la recette du boisson" )]
  public RecetteViewModelee RecetteViewModel { get; set; }

  public string Description { get; set; }
  public int? stock {  get; set; }
  }
 }
