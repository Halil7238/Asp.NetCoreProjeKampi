using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult NavbarMenuTop()
        {
            return PartialView();
        }
        public PartialViewResult NavbarMenuLeft()
        {
            return PartialView();
        }
    }
}
