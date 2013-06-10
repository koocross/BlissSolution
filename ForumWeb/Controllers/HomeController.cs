using System.Web.Mvc;
using Forum.Domain.Commands;

namespace ForumWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var createTopicCommand = new CreateTopicCommand("Billy", "About CQRS", "Are you interested in CQRS?");
            createTopicCommand.Send();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
