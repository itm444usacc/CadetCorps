using System.Web.Mvc;
using CadetCorps.Core.Interfaces;
using CadetCorps.ViewModels;

namespace CadetCorps.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Members Contoller.";

            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateMemberViewModel();

            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateMemberViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _memberService.CreateUser(viewModel);

                return RedirectToAction("Index");
            }

            return View("Create", viewModel);
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }

    }
}
