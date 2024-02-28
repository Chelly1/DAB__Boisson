using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Exception
 {
 public class AlreadyExistBoissonException : FormatException
  {


  public AlreadyExistBoissonException ( object key ) : base( $"Boisson Already Exist: {key}" )
   {
   }

  }
  }
