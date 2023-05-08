using Microsoft.AspNetCore.Mvc;

namespace QuranGuide.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult search_verse()
        {
            return View();
        }
    }
}
