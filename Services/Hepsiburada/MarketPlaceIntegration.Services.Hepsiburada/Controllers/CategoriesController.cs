using MarketPlaceIntegration.Services.Hepsiburada.ServerModels;
using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.Dtos;
using MarketPlaceIntegration.Shared.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace MarketPlaceIntegration.Services.Hepsiburada.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private string token;

        private RestClient client;
        private RestRequest request;

        [HttpGet]
        public IActionResult GetAllCategories(string page, string size)
        {
            token = TokenManager.GetToken($"{"yenibitrend_dev"}:{"ZfeqrE7zKwig!"}");

            client = new RestClient("https://mpop.hepsiburada.com/product/api/categories/get-all-categories?leaf=true&status=ACTIVE&available=true&page=" + page + "&size=" + size + "&version=1");
            client.Timeout = -1;
            request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Basic {token}");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            RootCategory category = JsonConvert.DeserializeObject<RootCategory>(response.Content);
            if (category.success)
            {
                return CreateActionResultInstance(Response<List<Category>>.Success(category.data, 200));
            }
            else
            {
                return CreateActionResultInstance(Response<List<Category>>.Fail(category.message, 400));
            }
        }

        [HttpGet]
        public IActionResult GetCategoryAttributes(string categoryId)
        {

            token = TokenManager.GetToken($"{"yenibitrend_dev"}:{"ZfeqrE7zKwig!"}");

            client = new RestClient("https://mpop.hepsiburada.com/product/api/categories/" + categoryId + "/attributes");
            client.Timeout = -1;

            request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Basic {token}");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            RootCategoryAttributes categoryAttributes = JsonConvert.DeserializeObject<RootCategoryAttributes>(response.Content);

            if (categoryAttributes.success)
            {
                return CreateActionResultInstance(Response<CategoryAttributes>.Success(categoryAttributes.data, 200));
            }
            else
            {
                return CreateActionResultInstance(Response<List<CategoryAttributes>>.Fail(categoryAttributes.message, 400));
            }
        }
    }
}
