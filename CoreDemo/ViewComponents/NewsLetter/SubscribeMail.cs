using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.NewsLetter
{
    public class SubscribeMail :ViewComponent
    {
        NewsletterManager nlm= new NewsletterManager(new EfNewsletterRepository());

       public IViewComponentResult Invoke(Newsletter newsletter)
        {
            newsletter.MailStatus = true;
            nlm.Add(newsletter);
            return View();
        }
    }
}
