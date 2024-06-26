using AutoMapper;

using DAB.Domain.Entities;
using DAB.Web.Models;

using Microsoft.Build.Framework;

using System.Data;
namespace DAB.Web.AutoMap.Helper
{

    public class AutoMappingProfiles : Profile
    {

        public AutoMappingProfiles()
        {
            #region Ingrediant
            CreateMap<IngredientViewModele, Ingredient>()

             .ForMember(dest => dest.Name,
                 opt => opt.MapFrom(src => $"{src.Name}")
                 )

             .ForMember(dest => dest.Price,
             opt => opt.MapFrom(src => $"{src.Price}")
             )

             .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => $"{src.Description}")
                )
             .ForMember(dest => dest.RecetteIngredients,
             opt => opt.MapFrom(src => src.recetteIngredientModeles)
       );

            CreateMap<Ingredient, IngredientViewModele>()

             .ForMember(dest => dest.Name,
             opt => opt.MapFrom(src => src.Name)
             )
             .ForMember(dest => dest.Price,
             opt => opt.MapFrom(src => src.Price)
             )
             .ForMember(dest => dest.Description,
             opt => opt.MapFrom(src => src.Description)
             )
             .ForMember(dest => dest.recetteIngredientModeles,
             opt => opt.MapFrom(src => $"{src.RecetteIngredients}")
             );



            #endregion

            #region Boisson

            CreateMap<Boisson, BoissonViewModele>()

             .ForMember(dest => dest.Name,
             opt => opt.MapFrom(src => $"{src.Name}")
             )
            .ForMember(dest => dest.Description,
              opt => opt.MapFrom(src => src.Description)
              )
            .ForMember(dest => dest.Boisson_Stock,
             opt => opt.MapFrom(src => src.Boisson_Stock)
            );

            CreateMap<BoissonViewModele, Boisson>()

             .ForMember(dest => dest.Name,
              opt => opt.MapFrom(src => src.Name)
              )
             .ForMember(dest => dest.Description,
             opt => opt.MapFrom(src => src.Description)
             )

             .ForMember(dest => dest.Boisson_Stock,
             opt => opt.MapFrom(src => src.Boisson_Stock)
             );

            #endregion
            #region Recette

            CreateMap<Recette, RecetteViewModele>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(dest => dest.Instructions,
                opt => opt.MapFrom(src => src.Instructions)
                )
                .ForMember(dest => dest.recetteIngredients,
                opt => opt.MapFrom(src => src.RecetteIngredients)
                );


            CreateMap<RecetteViewModele, Recette>()

             .ForMember(dest => dest.Name,
             opt => opt.MapFrom(src => src.Name)
             )
             .ForMember(dest => dest.Description,
             opt => opt.MapFrom(src => src.Description)
            )
             .ForMember(dest => dest.Instructions,
             opt => opt.MapFrom(src => src.Instructions)
             )
             .ForMember(dest => dest.RecetteIngredients,
             opt => opt.MapFrom(src => src.recetteIngredients)


             //.ForPath ( dest => dest.Boisson,
             //opt => opt.MapFrom(src => src.BoissonOfRecette )

             );


            CreateMap<RecipeCreateViewModel, Recette>()

 .ForMember(dest => dest.Name,
 opt => opt.MapFrom(src => src.Name)
 )
 .ForMember(dest => dest.Description,
 opt => opt.MapFrom(src => src.Description)
)
 .ForMember(dest => dest.Instructions,
 opt => opt.MapFrom(src => src.Instructions)
 )
 .ForMember(dest => dest.RecetteIngredients,
 opt => opt.MapFrom(src => src.Ingredients)

 //.ForPath ( dest => dest.Boisson,
 //opt => opt.MapFrom(src => src.BoissonOfRecette )

 );
            #endregion






        }


    }
}