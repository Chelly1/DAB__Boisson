using AutoMapper;

using DAB.Domain.Entities;
using DAB.Service.IRepository;
using DAB.Web.Models;
using DAB.Web.service;

using Microsoft.AspNetCore.Mvc;

using System.Drawing;

namespace DAB.Web.Controllers
 {
 public class IngrediantController : Controller
  {

  IIngredientRepository _ingrediantRepo;
  Iservice _service { get; set; }
  private readonly IMapper _mapper;


  public IngrediantController ( IIngredientRepository ingredientRepository, Iservice service, IMapper mapper )
   {
   this._ingrediantRepo = ingredientRepository;
   this._service = service;
   this._mapper = mapper;
   }

  [HttpGet]
  public ActionResult create ()
   {
   return View();
   }
  [HttpPost]
  public ActionResult create ( IngredientViewModele ingredientViewModele )
   {
   if ( !ModelState.IsValid )
    {
    return BadRequest( ModelState );
    }
   else
    {
    Ingredient ingredient=_mapper.Map<Ingredient>( ingredientViewModele);

    _service.AddIngredient( ingredient );
    return View( "Index" );

    }
   }
  /// <summary>
  /// List ingrediant
  /// </summary>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  [HttpGet]
  public IActionResult Index ()
   {

   List<IngredientViewModele> ingredientViewModelesList = new List<IngredientViewModele>();
   ICollection<Ingredient> ingrediantList = _service.GetAllIngrediant();

   if ( ingrediantList == null )
    {
    throw new Exception( "ingrediant non renseinger" );
    }
   else
    {
    foreach (var item in ingrediantList)
     {
     ingredientViewModelesList.Add(_mapper.Map<IngredientViewModele>( item ));
     }

    return View( ingredientViewModelesList.ToList() );
    }

   }

  [HttpGet]
  public ActionResult Edit ( int id )
   {
   if ( _service.FindIngredientById( id ) == null )
    {
    return BadRequest();
    }
   else
    {
    return View( _service.FindIngredientById( id ) );
    }
   }

  [HttpPost]
  public ActionResult Edit ( IngredientViewModele ingredientModele )
   {
   if ( !ModelState.IsValid )
    {
    return BadRequest();
    }
   else
    {
     return View( ingredientModele );
    }
  
   }


  public ActionResult DeleteIngrediant ()
   {
   return View();
   }

  public ActionResult EditIngrediant ()
   {
   return View();
   }
  }
 }
