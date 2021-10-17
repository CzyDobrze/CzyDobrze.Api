using Microsoft.AspNetCore.Mvc;

namespace CzyDobrze.Api.Controllers
{
    public class SectionController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}