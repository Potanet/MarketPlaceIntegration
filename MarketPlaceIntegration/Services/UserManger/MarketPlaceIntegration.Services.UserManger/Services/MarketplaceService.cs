using AutoMapper;
using MarketPlaceIntegration.Services.UserManger.IServices;
using MarketPlaceIntegration.Services.UserManger.Models;
using MarketPlaceIntegration.Shared.Settings;
using MarketPlaceIntegration.Shared.Dtos;
using MongoDB.Driver;

namespace MarketPlaceIntegration.Services.UserManger.Services
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly IMongoCollection<Marketplace> _marketplaceCollection;
        private readonly IMapper _mapper;

        public MarketplaceService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _marketplaceCollection = database.GetCollection<Marketplace>(databaseSettings.MarketplaceCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<MarketplaceDto>> CreateAsync(MarketplaceDto MarketplaceDto)
        {
            try
            {
                var Marketplace = _mapper.Map<Marketplace>(MarketplaceDto);
                await _marketplaceCollection.InsertOneAsync(Marketplace);

                return Response<MarketplaceDto>.Success(_mapper.Map<MarketplaceDto>(Marketplace), 200);
            }
            catch (Exception e)
            {
                return Response<MarketplaceDto>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<List<MarketplaceDto>>> GetAllAsync()
        {
            try
            {
                var marketplaces = await _marketplaceCollection.Find(Marketplace => true).ToListAsync();

                return Response<List<MarketplaceDto>>.Success(_mapper.Map<List<MarketplaceDto>>(marketplaces), 200);
            }
            catch (Exception e)
            {
                return Response<List<MarketplaceDto>>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<MarketplaceDto>> GetByIdAsync(string id)
        {
            Marketplace marketplaces = new Marketplace();
            try
            {
                marketplaces = await _marketplaceCollection.Find(x => x.Id.Equals(id)).FirstAsync();

                return Response<MarketplaceDto>.Success(_mapper.Map<MarketplaceDto>(marketplaces), 200);
            }
            catch (Exception e)
            {
                return Response<MarketplaceDto>.Fail(e.Message, 405);
            }
        }
    }
}
