using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.IRepository
 {
 public interface IRecetteRepository
  {
  void AddNewRecette(Recette recette);

  void DeleteRecette(Recette recette);

  Recette FindRecetteById ( int id );

  Recette FindRecetteByName(string name);
  
  Boisson Find_BoissonByRecette ( Recette recette );

  ICollection<Ingredient> IngredByRecette ( Recette recette );
  }
 }
