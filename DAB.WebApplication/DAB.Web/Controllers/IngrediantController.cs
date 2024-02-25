using DAB.Domain.Entities;
using DAB.Service.IRepository;
using DAB.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography.X509Certificates;

namespace DAB.Web.Controllers
 {
 public class IngrediantController : Controller
  {

  IIngredientRepository _ingrediantRepo;
  
  public IngrediantController(IIngredientRepository ingredientRepository)
   {
   this._ingrediantRepo = ingredientRepository;
   }

  public IActionResult Index ()
   {
   return View();
   }

  public ActionResult FindAll_Ingrediant()
   {
   return View( _ingrediantRepo.GetAllIngrediant().ToList() );
   }

  [HttpGet]
  public ActionResult AddIngrediant()
   {
   return View();
   }
  [HttpPost]
  public ActionResult AddIngrediant ( IngredientModele ingredientModele )
   {
   if ( !ModelState.IsValid )
    { }
   else {
    Ingredient _ingrediant= new Ingredient
     (
       ingredientModele.Name,
       ingredientModele.Description ,
       ingredientModele.Price
      );
    _ingrediantRepo.AddIngredient( _ingrediant );
    }
    return View();
     }

  public ActionResult DeleteIngrediant() 
   {
   return View();
   }

  public ActionResult EditIngrediant() {
   return View();
   }
  }
 }
