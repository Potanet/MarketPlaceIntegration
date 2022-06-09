using AutoMapper;
using MarketPlaceIntegration.Services.Products.IServices;
using MarketPlaceIntegration.Services.Products.Models;
using MarketPlaceIntegration.Shared.Dtos;
using MarketPlaceIntegration.Shared.Settings;
using MongoDB.Driver;


namespace MarketPlaceIntegration.Services.Products.Services
{
    public class UserStoreService : IUserStoreService
    {
        private readonly IMongoCollection<UserStore> _userStoreCollectionName;
        private readonly IMapper _mapper;

        public UserStoreService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _userStoreCollectionName = database.GetCollection<UserStore>(databaseSettings.UserStoreCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<UserStoreDto>> CreateAsync(UserStoreDto UserStoreDto)
        {
            try
            {
                UserStore userStore = _mapper.Map<UserStore>(UserStoreDto);
                await _userStoreCollectionName.InsertOneAsync(userStore);

                return Response<UserStoreDto>.Success(_mapper.Map<UserStoreDto>(userStore), 200);
            }
            catch (Exception e)
            {
                return Response<UserStoreDto>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<UserStoreDto>> CreateAsync(UserStoreDto UserStoreDto, string userId)
        {
            try
            {
                UserStore userStore = _mapper.Map<UserStore>(UserStoreDto);
                userStore.UserId = userId;
                await _userStoreCollectionName.InsertOneAsync(userStore);

                return Response<UserStoreDto>.Success(_mapper.Map<UserStoreDto>(userStore), 200);
            }
            catch (Exception e)
            {
                return Response<UserStoreDto>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<List<UserStoreDto>>> GetAllAsync()
        {
            try
            {
                var userStores = await _userStoreCollectionName.Find(Marketplace => true).ToListAsync();

                return Response<List<UserStoreDto>>.Success(_mapper.Map<List<UserStoreDto>>(userStores), 200);
            }
            catch (Exception e)
            {
                return Response<List<UserStoreDto>>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<UserStoreDto>> GetByIdAsync(string id)
        {
            try
            {
                var userStore = await _userStoreCollectionName.Find(x => x.Id.Equals(id)).FirstAsync();

                return Response<UserStoreDto>.Success(_mapper.Map<UserStoreDto>(userStore), 200);
            }
            catch (Exception e)
            {
                return Response<UserStoreDto>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<UserStoreDto>> GetByUserIdAsync(string userId)
        {
            try
            {
                var userStore = await _userStoreCollectionName.Find(x => x.UserId.Equals(userId)).FirstAsync();

                return Response<UserStoreDto>.Success(_mapper.Map<UserStoreDto>(userStore), 200);
            }
            catch (Exception e)
            {
                return Response<UserStoreDto>.Fail(e.Message, 405);
            }
        }
    }
}
