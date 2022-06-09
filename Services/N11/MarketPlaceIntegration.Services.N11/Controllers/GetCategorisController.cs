using Microsoft.AspNetCore.Mvc;
using N11CategoryService;

namespace MarketPlaceIntegration.Services.N11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetCategorisController : ControllerBase
    {
        private string strAppKey;
        private string strAppSecret;

        private Authentication authentication;

        public GetCategorisController()
        {
            strAppKey = "3be5564b-dfa8-4ad2-9e0f-3f5e7804dfbe";
            strAppSecret = "3jfkh6JH4Ah8fiJJ";

            authentication = new Authentication();
            authentication.appKey = strAppKey;
            authentication.appSecret = strAppSecret;
        }
        [HttpGet]
        public async Task<IActionResult> TopLevelAllCategories()
        {
            GetSubCategoriesRequest request = new GetSubCategoriesRequest();
            request.auth = authentication;

            //CategoryServicePort port = new CategoryServicePortService().getCategoryServicePortSoap11();
            //GetTopLevelCategoriesResponse topTopLevelCategoriesResponse = port.getTopLevelCategories(request);
            //List<SubCategory> categoryList = topTopLevelCategoriesResponse.getCategoryList().getCategory();


            return Ok();
        }
    }
}
