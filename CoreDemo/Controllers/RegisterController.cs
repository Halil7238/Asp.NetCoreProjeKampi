using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            writer.WriterStatus = true;
            writer.WriterAbout = "Deneme";
            writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(writer.WriterPassword); //Şifre Hash(Gizleme)
            wm.Add(writer);

            return RedirectToAction( "Index", "Blog");
        }
    }
}
