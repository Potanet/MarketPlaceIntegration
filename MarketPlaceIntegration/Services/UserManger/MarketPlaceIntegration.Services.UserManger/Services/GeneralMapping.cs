using AutoMapper;
using MarketPlaceIntegration.Services.UserManger.Models;
using MarketPlaceIntegration.Shared.Dtos;

namespace MarketPlaceIntegration.Services.UserManger.Services
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Marketplace, MarketplaceDto>();
            CreateMap<MarketplaceDto, Marketplace>();

            CreateMap<UserStore, UserStoreDto>();
            CreateMap<UserStoreDto, UserStore>();

            CreateMap<MarketplaceLoginDto, MarketplaceLogin>();
            CreateMap<MarketplaceLogin, MarketplaceLoginDto>();
        }
    }
}