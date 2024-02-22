using DAB.Domain.Entities;
using DAB.Service.IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Repository
 {
 public class IngredientRepository : IIngredientRepository
  {
  public void AddIngredient ( Ingredient ingredient )
   {
   throw new NotImplementedException();
   }

  public Ingredient FindIngredientBuId ( int id )
   {
   throw new NotImplementedException();
   }

  public Ingredient FindIngredientById ( int id )
   {
   throw new NotImplementedException();
   }

  public List<Ingredient> GetAllIngrediant ()
   {
   throw new NotImplementedException();
   }

  public decimal GetIngredientCost ( Ingredient ingredient )
   {
   throw new NotImplementedException();
   }

  public ICollection<Recette> RecetteIngrediant ( Ingredient ingredient )
   {
   throw new NotImplementedException();
   }

  public void SEtIngredientCost ( Ingredient ingredient, decimal cost )
   {
   throw new NotImplementedException();
   }
  }
 }
