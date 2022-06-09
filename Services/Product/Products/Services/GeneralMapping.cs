using AutoMapper;
using MarketPlaceIntegration.Services.Products.Models;
using MarketPlaceIntegration.Shared.Dtos;

namespace MarketPlaceIntegration.Services.Products.Services
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserStore, UserStoreDto>();
            CreateMap<UserStoreDto, UserStore>();

            CreateMap<MarketplaceLoginDto, MarketplaceLogin>();
            CreateMap<MarketplaceLogin, MarketplaceLoginDto>();
        }
    }
}