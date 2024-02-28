using DAB.Domain.IEntities;
using DAB.Service.IRepository;
using DAB.Web.Models;
using DBA.RespositoriesService1.Modele;
using DBA.RespositoriesService1;

using Microsoft.AspNetCore.Mvc;

namespace DAB.Web.Controllers
 {
 public class BoissonController : Controller
  {

  //private readonly IMapper _mapper;

  private IBoissonRepo _iboissonRepo { get; set; }
  BoissonViewModele BoissonViewModele { get; set; }
  IBoisson _iboisson { get; set; }

  Iservice1 _service { get; set; }


  public BoissonController ( Iservice1 iservice )
   {
   this._service = iservice;
   }

  [HttpGet]
  public ActionResult create ()
   {
   return View();
   }

  [HttpPost]
  public ActionResult Create ( BoissonViewModel boissonModel )
   {
   if ( !ModelState.IsValid )
    {
    return BadRequest();
    }
   else
    {
    _service.AddBoisson( boissonModel );
    return View( "Index","Home" );
    }
   }




   }
  }
