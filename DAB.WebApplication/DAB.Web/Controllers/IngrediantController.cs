using DAB.Domain.Entities;
using DAB.Service.IRepository;
using DAB.Web.Models;

using DBA.RespositoriesService1;
using DBA.RespositoriesService1.Modele;

using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography.X509Certificates;

namespace DAB.Web.Controllers
 {
 public class IngrediantController : Controller
  {

  IIngredientRepository _ingrediantRepo;
  Iservice1 _service { get; set; }


  public IngrediantController(IIngredientRepository ingredientRepository, Iservice1 service)
   {
   this._ingrediantRepo = ingredientRepository;
   this._service = service;
   }

  [HttpGet]
  public ActionResult create()
   {
   return View();
   }
  [HttpPost]
  public ActionResult create ( IngrediantViewModel ingrediantViewModele)
   {
   if(!ModelState.IsValid)
    {
    return BadRequest(ModelState);
    }
   else
    {
    _service.AddIngredient(ingrediantViewModele);
    return View("Index");

    }
   }

  [HttpGet]
  public IActionResult Index ()
   {

   ICollection<IngrediantViewModel> ingrediantList = _service.FindIngrediantViewModel();

   if ( ingrediantList == null )
    {
    throw new Exception( "ingrediant non renseinger" );
    }
   else
    {
    return View( ingrediantList );
    }

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
