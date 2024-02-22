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
  DabDbContext _dbContext = new DabDbContext();

  private readonly ILogger<HomeController> _logger;
  private readonly DabDbContext dbContext;
  IboissonRepo boissonRepo;
  //private readonly IMapper _mapper;


  public HomeController ( ILogger<HomeController> logger, IboissonRepo bookRepo)
   {
   _logger = logger;
   this.boissonRepo = bookRepo;
  
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
   return View(boissons); 
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
