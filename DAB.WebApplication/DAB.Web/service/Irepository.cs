using DAB.Domain.Entities;

namespace DAB.Web.service
 {
 public interface Irepository
  {
  void AddBoisson(Boisson boisson); 
  Recette Find_Boisson_Recette(Boisson boisson);
  List<Boisson> GetAll_Boisson ();
  List<Boisson> GetBoissonByIngredient(string ingredient);
  Decimal calculBoissonPrice ( Boisson boisson );


  }
 }
