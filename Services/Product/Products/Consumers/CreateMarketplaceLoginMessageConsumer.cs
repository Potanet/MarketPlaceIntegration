using MarketPlaceIntegration.Services.Products.IServices;
using MarketPlaceIntegration.Shared.Dtos;
using MassTransit;

namespace MarketPlaceIntegration.Services.Products.Consumers
{
    public class CreateMarketplaceLoginMessageConsumer : IConsumer<MarketplaceLoginDto>
    {
        private readonly IMarketplaceLoginService marketplaceLoginService;
        public CreateMarketplaceLoginMessageConsumer(IMarketplaceLoginService marketplaceLoginService)
        {
            this.marketplaceLoginService = marketplaceLoginService;
        }

        public async Task Consume(ConsumeContext<MarketplaceLoginDto> context)
        {
            var MarketplaceLogin = context.Message;
            marketplaceLoginService.CreateAsync(MarketplaceLogin).Wait();
        }
    }
}
