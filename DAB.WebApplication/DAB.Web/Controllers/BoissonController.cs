using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAB.Web.Controllers
 {
 public class BoissonController : Controller
  {
  // GET: BoissonController
  public ActionResult Index ()
   {
   return View();
   }

  // GET: BoissonController/Details/5
  public ActionResult Details ( int id )
   {
   return View();
   }

  // GET: BoissonController/Create
  public ActionResult Create ()
   {

   return View();
   }

  // POST: BoissonController/Creat

  // GET: BoissonController/Edit/5
  public ActionResult Edit ( int id )
   {
   return View();
   }

  // POST: BoissonController/Edit/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Edit ( int id, IFormCollection collection )
   {
   try
    {
    return RedirectToAction( nameof( Index ) );
    }
   catch
    {
    return View();
    }
   }

  // GET: BoissonController/Delete/5
  public ActionResult Delete ( int id )
   {
   return View();
   }

  // POST: BoissonController/Delete/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public ActionResult Delete ( int id, IFormCollection collection )
   {
   try
    {
    return RedirectToAction( nameof( Index ) );
    }
   catch
    {
    return View();
    }
   }
  }
 }
