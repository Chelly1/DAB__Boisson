using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.ExceptionMessage
 {
 internal class executionException : FormatException
  {
   private long _isbn =0;
   private long Isbn
    {
    get => _isbn;
    set => Isbn = value;
    }


   public executionException ( string mssg ) : base( String.Format( "enregiremenent enregistrement echecho" ) ) { }

   public executionException ( string mssg, long isbn ) : base( String.Format( " : {isbn}" ) ) { }

   public executionException ()
    {
    }



   }
  }
 
 
