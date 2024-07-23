using DAB.Data;
using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Repository
{
    public class RecetteRepository : IRecetteRepository
    {
        private readonly DabDbContext _dbContext;

        public RecetteRepository(DabDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddNewRecette(Recette recette)
        {
            if (recette == null)
            { throw new ArgumentNullException("Recette null pour etre ajouter"); }

            _dbContext.Recettes.Add(recette);
            

        }

        public void DeleteRecette(Recette recette)
        {
            if (recette == null)
            { throw new ArgumentNullException("Recette null pour etre ajouter"); }
            _dbContext.Recettes.Remove(recette);

        }


        public Recette FindRecetteById(int id)
        {
            Recette recette = new Recette();
            if(id == null)
            {
                throw new NotFoundException("id non renseigné");
            }
            if (_dbContext.Recettes.Where(rec => rec.Id == id).Count() > 0)
            {
                recette = _dbContext.Recettes.Where(rec=> rec.Id == id).FirstOrDefault();
            }
            
                
            //var recipe = _dbContext.Recettes
            //    .Include(r => r.RecetteIngredients)
            //    .ThenInclude(ri => ri.Ingredient).ToList();
            return recette;
        }

        public Recette FindRecetteByName(string name)
        {
            Recette recette;

            if (name == null)
            {
                throw new ArgumentNullException("");
            }
            else
            {
                recette = _dbContext.Recettes.Where(r => r.Name.Equals(name)).FirstOrDefault();
            }

            return recette;
        }
        public ICollection<RecetteIngredient> FindRecetteIngrediantByRecette(Recette recette)
        {
            if(recette == null)
            {
                throw new NotFoundException("recette not found {recette.Name}");
            }
            return _dbContext.RecetteIngredients.Where(t=>t.RecetteId== recette.Id).ToList();
        }

        public Boisson Find_BoissonByRecette(Recette recette)
        {
            throw new NotImplementedException();
        }

        public List<Recette> GetAll()
        {
            return _dbContext.Recettes.ToList();
        }

        public List<Recette> GetAllRecetteWithIngredient()
        {
            var recipes = _dbContext.Recettes
                .Include(r => r.RecetteIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .ToList();
            return recipes ;
        }

        public ICollection<Ingredient> IngredientByRecette(Recette recette)
        {
            List<RecetteIngredient> recetteIngredient = FindRecetteIngrediantByRecette(recette).ToList();

            List<Ingredient> ingredients = new List<Ingredient>();
            if (recetteIngredient != null)
            {
                foreach (var ring in recetteIngredient)
                {

                    ingredients.Add(_dbContext.Ingredients.Where(ig => ig.RecetteIngredients.Equals(ring)).SingleOrDefault());
                }

            }
            return ingredients.ToList();
        }
    

        public void UpdateRecette(Recette recette)
        {
            if (recette == null)
            {
                throw new DllNotFoundException("recette null");
            }
            _dbContext.Update(recette);
            _dbContext.SaveChanges();
        }
    }
}
