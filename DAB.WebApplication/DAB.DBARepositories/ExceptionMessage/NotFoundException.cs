using DAB.Service.Exception;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Exception
 {
 public class BoissonNotFoundException : FormatException
  {

  private long _isbn =0;
  private long Isbn
   {
   get => _isbn;
   set => Isbn = value;
   }


  public BoissonNotFoundException ( string mssg ) : base( String.Format( "Boisson not found" ) ){ }

  public BoissonNotFoundException ( string mssg, long isbn ) : base( String.Format( "Boisson not found : {isbn}" ) ) { }

  public BoissonNotFoundException ()
   {
   }
  }
 }




 