using System.Web.Mvc;

namespace CadetCorps.Controllers
{
    public class MembersController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Members Contoller.";

            return View("Index");
        }

        public ActionResult Create()
        {

            return View("Create");
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }

    }
}
