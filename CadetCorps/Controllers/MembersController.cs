using System.Web.Mvc;
using CadetCorps.Core.Interfaces;
using CadetCorps.ViewModels;
using SecurityGuard.Services;

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
            var list = _memberService.GetMembersList();

            return View("Index", list);
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

        public ActionResult Edit(int id)
        {
            var viewModel = _memberService.Read(id);

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(EditMemberViewModel viewModel)
        {
            return View("Edit");
        }
    }
}
