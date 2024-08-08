using Microsoft.AspNetCore.Mvc;

namespace Prince_Mobile_Collection.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
