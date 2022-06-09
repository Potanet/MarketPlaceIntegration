using MarketPlaceIntegration.Services.UserManger.Models;
using MarketPlaceIntegration.Shared.Dtos;

namespace MarketPlaceIntegration.Services.UserManger.IServices
{
    public interface IMarketplaceService
    {
        Task<Response<List<MarketplaceDto>>> GetAllAsync();

        Task<Response<MarketplaceDto>> CreateAsync(MarketplaceDto MarketplaceDto);

        Task<Response<MarketplaceDto>> GetByIdAsync(string id);
    }
}
