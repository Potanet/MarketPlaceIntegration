using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N11ProductService;

namespace MarketPlaceIntegration.Services.N11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            //int currentPageValue = 1;
            //int pageSizeValue = 100;

            //Authentication authentication = new Authentication();
            //authentication.appKey = strAppKey;
            //authentication.appSecret = strAppSecret;

            //RequestPagingData requestPagingData = new RequestPagingData
            //{
            //    currentPage = currentPageValue,
            //    pageSize = pageSizeValue
            //};

            //GetProductListRequest getProductListRequest = new GetProductListRequest
            //{
            //    auth = authentication,
            //    pagingData = requestPagingData
            //};

            //ProductServicePortService port = new ProductServicePortService();

            //GetProductListResponse response = port.GetProductList(getProductListRequest);

            return Ok();
        }

    }
}
