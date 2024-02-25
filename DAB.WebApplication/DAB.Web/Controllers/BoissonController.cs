using AutoMapper;

using DAB.Domain.Entities;
using DAB.Domain.IEntities;
using DAB.Service.IRepository;
using DAB.Web.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;



namespace DAB.Web.Controllers
 {
 public class BoissonController : Controller
  {
  //private readonly IMapper _mapper;

  private IBoissonRepo _iboissonRepo { get; set; }
  BoissonViewModele BoissonViewModele { get; set; }
  IBoisson _iboisson { get; set; }


  public BoissonController ( IBoissonRepo boissonRepo, IBoisson iboisson )//IMapper mapper )
   {

   this._iboissonRepo = boissonRepo;

   this._iboisson = iboisson;
   //this._mapper = mapper;
   }


  public IActionResult Index ()
   {
   List<Boisson> bossons = _iboissonRepo.FindAllBoisson().ToList();
   return View(bossons);

   }
   [HttpGet]
  public ActionResult create ()
   {
   return View( "create" );
   }
  [HttpPost]
  public ActionResult create ( Boisson boisson)
   {
   if ( !ModelState.IsValid )
    {
    return BadRequest();
    }
   else
    {
    _iboissonRepo.AddBoisson( boisson );
    return View(boisson);
    //return RedirectToAction( nameof( Index ) );
    }

   return View(boisson);
   }



  }
 }
