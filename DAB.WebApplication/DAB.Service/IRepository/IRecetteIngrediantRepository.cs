using DAB.Domain.Entities;
using DAB.Domain.IEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB.Service.IRepository
 {
 public interface IRecetteIngrediantRepository
  {
        void AddRecetteIngrediant(RecetteIngredient recetteIngrediant);
  List<RecetteIngredient> GetAllRecetteIngrediant ();

  List<RecetteIngredient> GetRecetteIngrediantsByIngrediant ( Ingredient ingrediant );
  List<RecetteIngredient> GetRecetteIngrediantsByRecette ( Recette recette );



  }
 }
