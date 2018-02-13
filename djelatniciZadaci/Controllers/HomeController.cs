using System.Web.Mvc;

namespace djelatniciZadaci.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Podaci o autoru";

            return View();
        }
    }
}