//using AutoMapper;

using DAB.Data;
using DAB.Domain.Entities;
using DAB.Domain.IEntities;
using DAB.Service.IRepository;
using DAB.Web.Models;

using DBA.RespositoriesService1;
using DBA.RespositoriesService1.Modele;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

using BoissonViewModele = DAB.Web.Models.BoissonViewModele;

namespace DAB.Web.Controllers
 {
 public class HomeController : Controller

  {


  private readonly ILogger<HomeController> _logger;

  Iservice1 _service { get; set; }
  //private readonly IMapper _mapper;


  public HomeController ( ILogger<HomeController> logger, Iservice1 service )
   {
   _logger = logger;
   this._service = service;

   }

  /// <summary>
  /// ListBoisson
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public ActionResult Index ()
   {
   List<Boisson> boissons = _service.getAllBoissson().ToList();
   //List<BoissonViewModele> boissonViewModele = _mapper.Map<BoissonViewModele>(boissons);
   return View();
   }



  [HttpGet]
  public ActionResult create ()
   {
   return View( "create" );
   }

  [HttpPost]
  public ActionResult create ( BoissonViewModel boissonViewModele )
   {
   if ( !ModelState.IsValid )
    {
    return BadRequest();
    }
   else
    {
    _service.AddBoisson( boissonViewModele );
    return View( boissonViewModele );
    }

   }



   public IActionResult Privacy ()
    {
    return View();
    }

   [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
   
   public IActionResult Error ()
    {
    return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
    }





   }
  
 }

