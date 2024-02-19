using System.Web;
using System.Web.Mvc;

namespace Distributeur_Auto_Boisson.WebApplication
 {
 public class FilterConfig
  {
  public static void RegisterGlobalFilters ( GlobalFilterCollection filters )
   {
   filters.Add( new HandleErrorAttribute() );
   }
  }
 }
