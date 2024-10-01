using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week5Auth.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
