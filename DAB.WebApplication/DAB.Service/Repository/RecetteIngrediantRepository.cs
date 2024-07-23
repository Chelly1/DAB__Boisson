using DAB.Data;
using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Repository
{
    public class RecetteIngrediantRepository : IRecetteIngrediantRepository
    {
        private readonly DabDbContext _dbContext;

        public RecetteIngrediantRepository(DabDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddRecetteIngrediant(RecetteIngredient recetteIngrediant)
        {
            _dbContext.RecetteIngredients.Add(recetteIngrediant);
            _dbContext.SaveChanges();

        }

        public List<RecetteIngredient> GetAllRecetteIngrediant()
        {
            if (_dbContext.RecetteIngredients == null)
            {
                throw new NotFoundException("recetteIngrediant null");
            }

            return _dbContext.RecetteIngredients.ToList();
        }

        public List<RecetteIngredient> GetRecetteIngrediantsByIngrediant(Ingredient ingrediant)
        {
            if (ingrediant == null)
            { throw new ArgumentNullException("ingrediant null"); }

            if (_dbContext.RecetteIngredients.Where(i => i.Ingredient.Equals(ingrediant)).Count() <= 0)
            {
                throw new NotFoundException("recette ingrediant not found");
            }

            return _dbContext.RecetteIngredients.Where(i => i.Ingredient.Equals(ingrediant)).ToList();
        }

        public List<RecetteIngredient> GetRecetteIngrediantsByRecette(Recette recette)
        {
            if (recette == null)
            {
                throw new ArgumentNullException("recette est null");
            }

            List<RecetteIngredient> recetteIngredientsList = _dbContext.RecetteIngredients.Where(t => t.RecetteId == recette.Id).ToList();
            if (recetteIngredientsList == null)
            {
                throw new ArgumentNullException("erreur recetteingrediant");
            }
            return _dbContext.RecetteIngredients.Where(t => t.RecetteId == recette.Id).ToList();
        }

    }
}

