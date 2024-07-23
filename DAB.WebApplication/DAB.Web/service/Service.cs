using AutoMapper;

using DAB.Domain.Entities;
using DAB.Service.Exception;
using DAB.Service.IRepository;
using DAB.Web.Models;

using System.Collections.Generic;

namespace DAB.Web.service
{
    public class Service : Iservice
    {
        #region declaration
        private readonly IMapper _mapper;

        private readonly IBoissonRepo _boissonRepo;
        private readonly IRecetteRepository _recetteRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecetteIngrediantRepository _recetteIngrediantRepository;

        public Service(IMapper mapper, IBoissonRepo boissonRepo, IRecetteRepository recetteRepository,
         IIngredientRepository ingredientRepository, IRecetteIngrediantRepository recetteIngrediantRepository)
        {
            _mapper = mapper;
            _boissonRepo = boissonRepo;
            _recetteRepository = recetteRepository;
            _ingredientRepository = ingredientRepository;
            _recetteIngrediantRepository = recetteIngrediantRepository;
        }
        #endregion

        /// <summary>
        /// ajout nouveau Boisson
        /// </summary>
        public void AddBoisson(Boisson boisson)
        {

            var mappedBoisson = _mapper.Map<Boisson>(boisson);

            _boissonRepo.AddBoisson(mappedBoisson);
        }

        public void AddBoissonstock(Boisson boisson, int stock)
        {
            if (boisson == null)
            {
                throw new ArgumentNullException(" selectionner boisson ");
            }
            else
            {
                boisson.Boisson_Stock += stock;
                _boissonRepo.UpdateBoisson(boisson);
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new Exception("Ajouter un bon ingredient");
            }
            else
            {
                _ingredientRepository.AddIngredient(ingredient);
            }
        }

        public void AddNewRecette(Recette recette)
        {
            if (recette == null)
            {
                throw new Exception("  pas dereccette à ajouter  ");
            }
            else
            {
                _recetteRepository.AddNewRecette(recette);
            }
        }

        public double CalculBoissonPrix(Boisson boisson)
        {
            double price = 0;
            Recette recette = boisson.Recette;
            List<Ingredient> ingredients = FindIngredientByRecette(recette);

            if (ingredients == null)
            { return price; }
            else
            {
                foreach (var ing in ingredients)
                {
                    price += ing.Price;
                }
            }
            return price;
        }

        public void DeleteRecette(Recette recette)
        {
            _recetteRepository.DeleteRecette(recette);
        }

        public ICollection<Ingredient> FindBoissantIngredients(Boisson boisson)
        {
            List<Ingredient> ingredients;
            if (boisson == null)
            {
                throw new NotFoundException("boisson no specifier");
            }
            else
            {
                ingredients = FindIngredientByRecette(boisson.Recette);
            }
            return ingredients;
        }

        public Boisson FindBoissonByName(string name)
        {
            return _boissonRepo.FindBoissonByName(name);
        }

        public Recette FindBoissonRcette(Boisson boisson)
        {
            throw new NotImplementedException();
        }

        public Ingredient FindIngredientById(int id)
        {
            return _ingredientRepository.FindIngredientById(id);
        }

        public List<Ingredient> FindIngredientByRecette(Recette recette)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            List<RecetteIngredient> recetteIngredients = new List<RecetteIngredient>();
            if (recette == null)
            {
                throw new NotFoundException("recette not specifier");
            }
            else
            {
                recetteIngredients = _recetteIngrediantRepository.GetRecetteIngrediantsByRecette(recette).ToList();

            }
            foreach (var ing in recetteIngredients)
            {
                ingredients.Add(ing.Ingredient);
            }
            return ingredients;
        }

        public Recette FindRecetteById(int id)
        {
            Recette recette =  _recetteRepository.FindRecetteById(id);
             recette.RecetteIngredients = _recetteIngrediantRepository.GetRecetteIngrediantsByRecette(recette);
            return recette;

        }

        public ICollection<Recette> FindRecetteByIngrediant(Ingredient ingredient)
        {
            List<RecetteIngredient> recetteIngredients = _recetteIngrediantRepository.GetRecetteIngrediantsByIngrediant(ingredient);

            List<Recette> recettes = new List<Recette>();
            foreach (var rI in recetteIngredients)
            {
                if (rI != null && rI.Recette != null)
                {
                    recettes.Add(rI.Recette);
                }

            }
            return recettes;
        }

        public Recette FindRecetteByName(string name)
        {
            return _recetteRepository.FindRecetteByName(name);
        }

        public ICollection<RecetteIngredient> FindRecetteIngrediantByIngrediant(Ingredient ingredient)
        {
            return _recetteIngrediantRepository.GetRecetteIngrediantsByIngrediant(ingredient);
        }

        public Boisson Find_BoissonByRecette(Recette recette)
        {
            if (recette == null)
            {
                throw new NotFoundException("recette not speciphied");
            }
            else
            {
                return _recetteRepository.Find_BoissonByRecette(recette);
            }

        }

        public Boisson FinfBoissonById(int id)
        {
            return _boissonRepo.FindsBoissonById(id);
        }

        public ICollection<Boisson> FindAllBoisson()
        {
            return _boissonRepo.FindAllBoisson();
        }


        public ICollection<Ingredient> FindAllIngrediant()
        {
            return _ingredientRepository.GetAllIngrediant();
        }

        public double FindIngredientCost(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new NotFoundException("ingredient not found");
            }
            else
            {
                return ingredient.Price;
            }

        }

        public ICollection<Ingredient> IngrediantByRecette(Recette recette)
        {
            return FindIngredientByRecette(recette);
        }

        public void SetIngredientCost(Ingredient ingredient, double cost)
        {
            ingredient.Price = cost;
            _ingredientRepository.updateIngrediant(ingredient);
        }

        public void UpdateBoisson(Boisson boisson)
        {
            if (boisson == null)
            {
                throw new NotFoundException("boisson not found");
            }
            _boissonRepo.UpdateBoisson(boisson);
        }

        public List<Recette> FindAllRecette()
        {
            return _recetteRepository.GetAll().ToList();
        }

        public List<Recette> GetAllRecetteAvecIngredients()
        {
            return _recetteRepository.GetAllRecetteWithIngredient().ToList();
        }

        public void UpdateRecette(Recette recette)
        {
            _recetteRepository.UpdateRecette(recette);
        }

        public ICollection<Ingredient> FindIngrediantByRecette(Recette recette)
        {
            if (recette == null)
            {
                throw new NotFoundException("recette null");
            }

            List<Ingredient> IngredientsList = new List<Ingredient>();
            List<RecetteIngredient> recetteIngredien =
                    _recetteIngrediantRepository.GetRecetteIngrediantsByRecette(recette).ToList();

            if (recetteIngredien != null)
            {
                foreach (var ring in recetteIngredien)
                {
                    IngredientsList.Add(ring.Ingredient);
                }

            }
            return IngredientsList.ToList();

        }

        public void AddRecetteIngredient(RecetteIngredient recetteIngredient)
        {
            if (recetteIngredient != null)
            {
                _recetteIngrediantRepository.AddRecetteIngrediant(recetteIngredient);
            }
        }

        public List<Ingredient> FrindIngredientByRecette(Recette recette)
        {
            List<RecetteIngredient> recetteIngredientList = _recetteIngrediantRepository.GetRecetteIngrediantsByRecette(recette).ToList();


            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var ri in recetteIngredientList)
            {
                ingredients.Add(ri.Ingredient);
            }
            return ingredients;
        }


        //----
        public void CreateRecette(Recette recette, int[] ingredientIds,
                                     double[] quantities, string[] units)
        {

           

            for (int i = 0; i < ingredientIds.Length; i++)
            {

                RecetteIngredient recetteIngrediant = new RecetteIngredient
                {
                    Recette = recette,
                    Ingredient = FindIngredientById(ingredientIds[i]),
                    RecetteId = recette.Id,
                    IngredientId = ingredientIds[i],
                    Dose = quantities[i],
                    Unite = "ee" //units[i]
                };
                AddRecetteIngredient(recetteIngrediant);
                recette.RecetteIngredients.Add(recetteIngrediant);
                AddNewRecette(recette);
            }
        }

        public ICollection<RecetteIngredient> FindAllRecetteIngrediant()
        {
           return _recetteIngrediantRepository.GetAllRecetteIngrediant().ToList();
        }

        public ICollection<RecetteIngredient> FindRecetteIngrediantByRecette(Recette recette)
        {
           return _recetteIngrediantRepository.GetRecetteIngrediantsByRecette(recette).ToList();

        }
    }

}
