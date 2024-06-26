using AutoMapper;

using DAB.Domain.Entities;
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
            var Recipe = _service.GetAllRecetteAvecIngredients().ToList();
           if( Recipe == null)
            {
                return NotFound();
            }
           List<RecetteViewModele> recetteViewModele = new List<RecetteViewModele>();
           foreach (var item in Recipe)
            {
                recetteViewModele.Add(_mapper.Map<RecetteViewModele>(item));

            }
            return View(recetteViewModele);


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
        public ActionResult Create(RecetteViewModele recetteViewModele, int[] ingredientIds,
                                     double[] quantities, string[] units)
        {
            if (ModelState.IsValid)
            {
                return View(recetteViewModele);

            }
            else
            {
                Recette recette = _mapper.Map<Recette>(recetteViewModele);


                for (int i = 0; i >=ingredientIds.Length; i++)
                {
                    RecetteIngredient recetteIngredient = new RecetteIngredient();


                    recetteIngredient.RecetteId = recette.Id;
                       recetteIngredient.IngredientId = ingredientIds[i];
                        recetteIngredient.Dose = quantities[i];
                    recetteIngredient.Unite = units[i];

                   // RecetteIngredient recetteIngredientmapped = _mapper.Map<RecetteIngredient>(recetteIngredient);
                    recette.RecetteIngredients.Add(recetteIngredient);
                }
                    _service.AddNewRecette(recette);



                }
                return RedirectToAction(nameof(Index));
            }



        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var recip = _service.FindRecetteById(id);
            if(recip == null)
            {
                return NotFound();
            }
            RecetteViewModele result = _mapper.Map<RecetteViewModele>(recip);

            ViewBag.IngredientOfRecette = _service.FindIngredientByRecette(recip);
            return View(result);
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
        public ActionResult Edit(int id, IFormCollection collection)
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

