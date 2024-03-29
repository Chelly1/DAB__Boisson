﻿using DAB.Service.Exception;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.Exception
 {
 public class NotFoundException : FormatException
  {

  private long _isbn =0;
  private long Isbn
   {
   get => _isbn;
   set => Isbn = value;
   }


  public NotFoundException ( string mssg ) : base( String.Format( " not found" ) ){ }

  public NotFoundException ( string mssg, long isbn ) : base( String.Format( " not found : {isbn}" ) ) { }

  public NotFoundException ()
   {
   }
  }
 }




 