using AutoMapper;

using DAB.Domain.Entities;
using DAB.Domain.IEntities;
using DAB.Web.Models;
using DAB.Web.service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAB.Web.Controllers
{
    public class RecetteController : Controller
    {
        private readonly Iservice _service;
        private readonly IMapper _mapper;

        public RecetteController(Iservice service, IMapper mapper)
        {
            this._mapper = mapper;
            _service = service;
        }
        // GET: Recette1Controller


        // GET: Recette1Controller/Details/5



        public ActionResult Index()
        {
            RecetteViewModele recetteViewModele1 = new RecetteViewModele();
            var Recipe = _service.GetAllRecetteAvecIngredients().ToList();
            IngredientViewModele testm = new IngredientViewModele();
            if (Recipe == null)
            {
                return NotFound();
            }
            List<RecetteViewModele> recetteViewModeleList = new List<RecetteViewModele>();

            foreach (var item in Recipe)
            {
                List<Ingredient> ingredientList = _service.FindIngredientByRecette(item).ToList();

                if (ingredientList != null)
                {


                    recetteViewModele1 = _mapper.Map<RecetteViewModele>(item);

                    foreach (var ingred in ingredientList)
                    {

                        testm = _mapper.Map<IngredientViewModele>(ingred);
                        testm.Unit = "m";
                        if (testm != null)
                        {

                            recetteViewModele1.Ingredients.Add(testm);
                        }

                        recetteViewModeleList.Add(recetteViewModele1);
                    }



                }


            }
            return View(recetteViewModeleList);


        }
        // GET: Recette1Controller/Create
        public ActionResult Create()
        {

            ViewBag.Ingredients = _service.FindAllIngrediant().ToList();

            return View();
        }

        // POST: Recette1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecetteViewModele recetteviewModele, int[] ingredientIds,
                                     double[] quantities, string[] units)
        {

            if (ModelState.IsValid)
            {
                return View(recetteviewModele);


            }
            else
            {
                Recette recette = _mapper.Map<Recette>(recetteviewModele);

                _service.CreateRecette(recette, ingredientIds, quantities, units);



                //        for (int i= 0 ; i < ingredientIds.Length; i++)
                //            {
                //            RecetteIngredient recetteIngrediant = new RecetteIngredient
                //            {
                //                RecetteId = recette
                //            }

                //            }
                //        recetteViewModele.SelectedIngredientIds = ingredientIds;
                //        Recette recette = _mapper.Map<Recette>(recetteViewModele);
                //        _service.AddNewRecette(recette);
                //        for (int i = 0; i <=ingredientIds.Length; i++)
                //        {
                //            //tjib ingrediant ou tajoutihom il recette ingrediant

                //            RecetteIngredient recetteIngredient = new RecetteIngredient();


                //            List<Ingredient> ingredients = _service.FindIngredientByRecette(recette);

                //            recetteIngredient.Recette = recette;

                //                recetteIngredient.Dose = quantities[i];
                //            recetteIngredient.Unite = "lm";

                //           // RecetteIngredient recetteIngredientmapped = _mapper.Map<RecetteIngredient>(recetteIngredient);

                //            _service.AddRecetteIngredient(recetteIngredient);
                //            recette.RecetteIngredients.Add(recetteIngredient);

                //        }


            }
            return RedirectToAction(nameof(Index));
        }



        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        
        {
            if (id == null)
            {
                return NotFound();
            }
            Recette recette = _service.FindRecetteById(id);

            ViewBag.Ingrediant = _service.FindIngredientByRecette(recette);
            if (recette == null)
            {
                return NotFound();
            }

            //List<RecetteIngredient> rectIng = _service.FindRecetteIngrediantByRecette(recette).ToList();
            //recette.RecetteIngredients = rectIng;
            RecetteViewModele recetteViewModele = _mapper.Map<RecetteViewModele>(recette);

            List<Ingredient> ingredients = _service.FrindIngredientByRecette((recette));
            if (ingredients.Count > 0)
            {
                foreach (var ing in ingredients)
                {
                    IngredientViewModele ingredientViewModele = _mapper.Map<IngredientViewModele>(ing);
                    recetteViewModele.Ingredients.Add(ingredientViewModele);
                }
            }



            return View(recetteViewModele);
        }

        // GET: Recette1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Recette recet = _service.FindRecetteById(id);
            if (recet == null)
            {
                return NotFound();
            }
            ViewBag.IngredientOfRecette = _service.FindIngredientByRecette(recet);
            ViewBag.Ingredient = _service.FindAllIngrediant().ToList();

            return View(recet);
        }

        // POST: Recette1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecetteViewModele recetteViewModele,int[] ingrediantId, double[] quantities
            , string[] units)
        {
            if(recetteViewModele == null)
            {
                return BadRequest();
            }
            Recette recette = _mapper.Map<Recette>(recetteViewModele);
            if ( (_service.FindRecetteById(id)).Equals(recette))
            {
                return NotFound();

            }
            if(ModelState.IsValid)
            {
              
                    _service.UpdateRecette(recette);
                    var existingIngrediant = _service.FindAllRecetteIngrediant().Where(p => p.Recette.Equals(recette));

                


            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: Recette1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recette1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

