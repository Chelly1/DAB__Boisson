using DAB.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.IRepository
 {
 public interface IBoissonRepo
  {
  ICollection<Boisson> FindAllBoisson ();

  void AddBoisson ( Boisson boisson );

  void AddBoissonStock ( Boisson boisson, int stock );

  void UpdateBoisson ( Boisson boisson );

  
  Boisson? FindsBoissonById ( int id );

  Boisson? FindBoissonByName ( string name );

  Recette FindBoissonRcette ( Boisson boisson );
  
  
  Double CalculBoissonPrix( Boisson boisson );
  public ICollection<Ingredient> FindBoissantIngredients ( Boisson boisson );


  }
 }
