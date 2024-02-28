using DAB.Domain.Entities;
using DAB.Service.IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Repository
 {
 public class RecetteRepository : IRecetteRepository
  {
  public void AddNewRecette ( Recette recette )
   {
   throw new NotImplementedException();
   }

  public void DeleteRecette ( Recette recette )
   {
   throw new NotImplementedException();
   }

  public Recette FindRecetteBuId ( int id )
   {
   throw new NotImplementedException();
   }

  public Recette FindRecetteById ( int id )
   {
   throw new NotImplementedException();
   }

  public Recette FindRecetteByName ( string name )
   {
   throw new NotImplementedException();
   }

  public Boisson Find_BoissonByRecette ( Recette recette )
   {
   throw new NotImplementedException();
   }

  public ICollection<Ingredient> IngredByRecette ( Recette recette )
   {
   throw new NotImplementedException();
   }
  }
 }
