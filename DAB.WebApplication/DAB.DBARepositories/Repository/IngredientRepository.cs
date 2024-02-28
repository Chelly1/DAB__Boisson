using DAB.Data;
using DAB.Domain.Entities;
using DAB.Service.IRepository;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Repository
 {

 public class IngredientRepository : IIngredientRepository
  {

  private readonly DabDbContext _dbContext;

  public IngredientRepository(DabDbContext dbContext) 
   {
   this._dbContext = dbContext;
   }
  public void AddIngredient ( Ingredient ingredient )
   {
   if(ingredient !=  null)
    _dbContext.Ingredients.Add( ingredient );
    
   }

  public Ingredient FindIngredientById ( int id )
   {
   throw new NotImplementedException();
   }

  public ICollection<Ingredient> GetAll ()
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