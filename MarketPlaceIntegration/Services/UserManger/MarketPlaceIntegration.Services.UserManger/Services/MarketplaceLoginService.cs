using AutoMapper;
using MarketPlaceIntegration.Services.UserManger.IServices;
using MarketPlaceIntegration.Services.UserManger.Models;
using MarketPlaceIntegration.Shared.Dtos;
using mass = MassTransit;
using MongoDB.Driver;
using MarketPlaceIntegration.Shared.Settings;

namespace MarketPlaceIntegration.Services.UserManger.Services
{
    public class MarketplaceLoginService : IMarketplaceLoginService
    {
        private readonly IMongoCollection<MarketplaceLogin> _marketplaceLoginCollection;
        private readonly IMapper _mapper;
        //private readonly mass.ISendEndpointProvider sendEndpointProvider;
        private readonly mass.IPublishEndpoint publishEndpoint;

        public MarketplaceLoginService(IMapper mapper, IDatabaseSettings databaseSettings,
                                        //mass.ISendEndpointProvider sendEndpointProvider, 
                                        mass.IPublishEndpoint publishEndpoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _marketplaceLoginCollection = database.GetCollection<MarketplaceLogin>(databaseSettings.MarketplaceLoginCollectionName);
            _mapper = mapper;

            //this.sendEndpointProvider = sendEndpointProvider;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<Response<MarketplaceLoginDto>> CreateAsync(MarketplaceLoginDto marketplaceLoginDto)
        {
            try
            {
                var marketplaceLogin = _mapper.Map<MarketplaceLogin>(marketplaceLoginDto);
                await _marketplaceLoginCollection.InsertOneAsync(marketplaceLogin);

                //var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-marketplaceLogin-for-order"));
                //sendEndpoint.ex
                //await sendEndpoint.Send<MarketplaceLoginDto>(marketplaceLoginDto);

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
                List<MarketplaceLogin> marketplaceLogins = _mapper.Map<List<MarketplaceLogin>>(marketplaceLoginDtos);

                await _marketplaceLoginCollection.InsertManyAsync((List<MarketplaceLogin>)marketplaceLogins);

                //var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-marketplaceLogins-for-order"));
                ////sendEndpoint.ex
                //foreach (var marketplaceLoginDto in marketplaceLoginDtos)
                //{
                //    await sendEndpoint.Send<MarketplaceLoginDto>(marketplaceLoginDto);
                //}

                foreach (var marketplaceLoginDto in marketplaceLoginDtos)
                {
                    await publishEndpoint.Publish<MarketplaceLoginDto>(marketplaceLoginDto);
                }

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
