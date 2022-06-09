using MarketPlaceIntegration.Shared.Dtos;

namespace MarketPlaceIntegration.Services.UserManger.IServices
{
    public interface IMarketplaceLoginService
    {
        Task<Response<List<MarketplaceLoginDto>>> GetAllAsync();

        Task<Response<MarketplaceLoginDto>> CreateAsync(MarketplaceLoginDto marketplaceLoginDto);
         
        Task<Response<List<MarketplaceLoginDto>>> CreateRangeAsync(List<MarketplaceLoginDto> marketplaceLoginDtos);

        Task<Response<MarketplaceLoginDto>> GetByIdAsync(string id);
    }
}
