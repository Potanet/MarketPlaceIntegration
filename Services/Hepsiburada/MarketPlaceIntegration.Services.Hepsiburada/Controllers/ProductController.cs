using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MarketPlaceIntegration.Services.Hepsiburada.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private string token;

        private RestClient client;
        private RestRequest request;

        [HttpGet]
        public IActionResult GetAllProducts(string page, string size)
        {
            token = TokenManager.GetToken($"{"yenibitrend_dev"}:{"ZfeqrE7zKwig!"}");

            client = new RestClient("https://mpop.hepsiburada.com/product/api/products/products-by-merchant-and-status?page=" + page + "&size=" + size + "&version=1&merchantId=71d2c9a5-f49e-4da1-b4d8-ca5107079fd7&productStatus=MATCHED&taskStatus=false");
            client.Timeout = -1;

            request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Basic {token}");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            //if (category.success)
            //{
            //    return CreateActionResultInstance(Response<List<Category>>.Success(category.data, 200));
            //}
            //else
            //{
            //    return CreateActionResultInstance(Response<List<Category>>.Fail(category.message, 400));
            //}
            return Ok(response.Content);
        }
    }
}
