using AutoMapper;

using DAB.Domain.Entities;
using DAB.Web.Models;

using Microsoft.Build.Framework;

using System.Data;
namespace DAB.Web.AutoMap.Helper
 {

 public class AutoMappingProfiles : Profile
  {

  public AutoMappingProfiles ()
   {
   #region Ingrediant
   CreateMap<IngredientViewModele, Ingredient>()

    .ForMember( dest => dest.Name,
        opt => opt.MapFrom( src => $"{src.Name}" )
        )

    .ForMember( dest => dest.Price,
    opt => opt.MapFrom( src => $"{src.Price}" )
    )

    .ForMember( dest => dest.Description,
       opt => opt.MapFrom( src => $"{src.Description}" )
       );

   CreateMap<Ingredient, IngredientViewModele>()

    .ForMember( dest => dest.Name,
    opt => opt.MapFrom( src => src.Name )
    )
    .ForMember( dest => dest.Price,
    opt => opt.MapFrom( src => src.Price )
    )
    .ForMember( dest => dest.Description,
    opt => opt.MapFrom( src => src.Description )
    );



   #endregion

   #region Boisson

   CreateMap<Boisson, BoissonViewModele>()

    .ForMember( dest => dest.Name,
    opt => opt.MapFrom( src => $"{src.Name}" )
    )
   .ForMember( dest => dest.Description,
     opt => opt.MapFrom( src => src.Description )
     )
   .ForMember( dest => dest.Boisson_Stock,
    opt => opt.MapFrom( src => src.Boisson_Stock )
   );

   CreateMap<BoissonViewModele, Boisson>()

    .ForMember( dest => dest.Name,
     opt => opt.MapFrom( src => src.Name )
     )
    .ForMember( dest => dest.Description,
    opt => opt.MapFrom( src => src.Description )
    )

    .ForMember( dest => dest.Boisson_Stock,
    opt => opt.MapFrom( src => src.Boisson_Stock )
    );
    
   #endregion

   CreateMap<RecetteViewModele, Recette>()

    .ForMember( dest => dest.Name,
    opt => opt.MapFrom( src => src.Name )
    )
    .ForMember(dest => dest.Description,
    opt => opt.MapFrom(src =>src.Description)
   )
    .ForPath ( dest => dest.Boisson,
    opt => opt.MapFrom(src => src.BoissonOfRecette )
    );

    //.ForMember(dest => dest.RecetteIngredients),
    //opt => opt.MapFrom(src => src .)





   }


  }
 }