using AutoMapper;
using MarketPlaceIntegration.Services.Products.IServices;
using MarketPlaceIntegration.Services.Products.Models;
using MarketPlaceIntegration.Shared.Dtos;
using MarketPlaceIntegration.Shared.Settings;
using MongoDB.Driver;

namespace MarketPlaceIntegration.Services.Products.Services
{
    internal class MarketplaceLoginService : IMarketplaceLoginService
    {
        private readonly IMongoCollection<MarketplaceLogin> _marketplaceLoginCollection;
        private readonly IMapper _mapper;

        public MarketplaceLoginService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _marketplaceLoginCollection = database.GetCollection<MarketplaceLogin>(databaseSettings.MarketplaceLoginCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<MarketplaceLoginDto>> CreateAsync(MarketplaceLoginDto marketplaceLoginDto)
        {
            try
            {
                var marketplaceLogin = _mapper.Map<MarketplaceLogin>(marketplaceLoginDto);
                await _marketplaceLoginCollection.InsertOneAsync(marketplaceLogin);

                return Response<MarketplaceLoginDto>.Success(_mapper.Map<MarketplaceLoginDto>(marketplaceLogin), 200);
            }
            catch (Exception e)
            {
                return Response<MarketplaceLoginDto>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<List<MarketplaceLoginDto>>> CreateRangeAsync(List<MarketplaceLoginDto> marketplaceLoginDtos)
        {
            try
            {
                var marketplaceLogins = _mapper.Map<List<MarketplaceLoginDto>>(marketplaceLoginDtos);

                await _marketplaceLoginCollection.InsertManyAsync((IEnumerable<MarketplaceLogin>)marketplaceLogins);

                return Response<List<MarketplaceLoginDto>>.Success(_mapper.Map<List<MarketplaceLoginDto>>(marketplaceLogins), 200);
            }
            catch (Exception e)
            {
                return Response<List<MarketplaceLoginDto>>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<List<MarketplaceLoginDto>>> GetAllAsync()
        {
            try
            {
                var marketplaceLogins = await _marketplaceLoginCollection.Find(Marketplace => true).ToListAsync();

                return Response<List<MarketplaceLoginDto>>.Success(_mapper.Map<List<MarketplaceLoginDto>>(marketplaceLogins), 200);
            }
            catch (Exception e)
            {
                return Response<List<MarketplaceLoginDto>>.Fail(e.Message, 405);
            }
        }

        public async Task<Response<MarketplaceLoginDto>> GetByIdAsync(string id)
        {
            try
            {
                var marketplaceLogin = await _marketplaceLoginCollection.Find(x => x.Id.Equals(id)).FirstAsync();

                return Response<MarketplaceLoginDto>.Success(_mapper.Map<MarketplaceLoginDto>(marketplaceLogin), 200);
            }
            catch (Exception e)
            {
                return Response<MarketplaceLoginDto>.Fail(e.Message, 405);
            }
        }
    }
}
