using Microsoft.AspNetCore.Mvc;
using Prince_Mobile_Collection.API_Helper;
using Prince_Mobile_Collection.Models.NewFolder;
using PrinceApi.Models.SiteUser;
using System.Text.Json;

namespace Prince_Mobile_Collection.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductController> _logger;
        public AccountController(IHttpClientFactory httpClientFactory, ILogger<ProductController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;

        }
        public ActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> UpsertSiteUser([FromBody]SiteUserModel siteUserModel)
        {
            if (siteUserModel == null)
            {
                return BadRequest("Fields cannot be null");
            }

            try
            {
                // Use HttpClientFactory to create HttpClient instance
                var httpClient = _httpClientFactory.CreateClient();
                var jsonContent = JsonSerializer.Serialize(siteUserModel);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Post request
                var response = await httpClient.PostAsync(APIClient.UpsertSiteUser, content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var dbResponse = JsonSerializer.Deserialize<BoolResponse>(apiResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return Json(dbResponse);
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
