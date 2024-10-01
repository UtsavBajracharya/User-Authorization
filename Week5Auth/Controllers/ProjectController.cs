using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week5Auth.Controllers
{
    [Authorize(Roles = "User")]
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
