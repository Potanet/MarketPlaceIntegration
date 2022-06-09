using MarketPlaceIntegration.Shared.Dtos;

namespace MarketPlaceIntegration.Services.Products.IServices
{
    public interface IUserStoreService
    {
        Task<Response<List<UserStoreDto>>> GetAllAsync();

        Task<Response<UserStoreDto>> CreateAsync(UserStoreDto UserStoreDto);
        Task<Response<UserStoreDto>> CreateAsync(UserStoreDto UserStoreDto, string userId);

        //Task<Response<UserStoreDto>> CreateRangeAsync(List<UserStoreDto> UserStoreDtos);

        Task<Response<UserStoreDto>> GetByIdAsync(string id);
        Task<Response<UserStoreDto>> GetByUserIdAsync(string userId);
    }
}
