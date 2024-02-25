//using AutoMapper;

using DAB.Data;
using DAB.Domain.Entities;
using DAB.Domain.IEntities;
using DAB.Service.IRepository;
using DAB.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace DAB.Web.Controllers
 {
 public class HomeController : Controller

  {
  DabDbContext _dbContext ;

  private readonly ILogger<HomeController> _logger;
  private readonly DabDbContext dbContext;
  IBoissonRepo boissonRepo;
  //private readonly IMapper _mapper;


  public HomeController ( ILogger<HomeController> logger, IBoissonRepo bookRepo)
   {
   _logger = logger;
   this.boissonRepo = bookRepo;
  
   }


  [HttpGet]
  public ActionResult create ()
   {
   return View( "create" );
   }
  [HttpPost]
  public ActionResult create ( Boisson boisson )
   {
   if ( !ModelState.IsValid )
    {
    return BadRequest();
    }
   else
    {
    boissonRepo.AddBoisson( boisson );
    return View( boisson );
    //return RedirectToAction( nameof( Index ) );
    }

   return View( boisson );
   }

  /// <summary>
  /// ListBoisson
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public ActionResult Index()
   {
 
   List<Boisson> boissons = boissonRepo.FindAllBoisson().ToList();
   //List<BoissonViewModele> boissonViewModele = _mapper.Map<BoissonViewModele>(boissons);
   return View(); 
   }
  
  public IActionResult Privacy ( )
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
