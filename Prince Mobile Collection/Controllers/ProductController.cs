using Microsoft.AspNetCore.Mvc;
using Prince_Mobile_Collection.API_Helper;
using Prince_Mobile_Collection.Models.Products;
using System.Text.Json;

namespace Prince_Mobile_Collection.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IHttpClientFactory httpClientFactory, ILogger<ProductController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetProducts(ProductsModel productsModel)
        {
            if (productsModel == null)
            {
                return BadRequest("ProductsModel cannot be null");
            }

            try
            {
                // Use HttpClientFactory to create HttpClient instance
                var httpClient = _httpClientFactory.CreateClient();
                var jsonContent = JsonSerializer.Serialize(productsModel);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Post request
                var response = await httpClient.PostAsync(APIClient.GetProducts, content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var productsList = JsonSerializer.Deserialize<List<ProductsModel>>(apiResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return Json(productsList);
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"API returned an error: {response.StatusCode} - {errorResponse}");
                    return StatusCode((int)response.StatusCode, errorResponse);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Request error while calling the API.");
                return StatusCode(500, "Internal server error.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
