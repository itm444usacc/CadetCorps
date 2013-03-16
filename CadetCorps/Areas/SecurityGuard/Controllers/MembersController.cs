using System.Web.Mvc;
using CadetCorps.Areas.SecurityGuard.ViewModels.Members;
using CadetCorps.Core.Interfaces;

namespace CadetCorps.Areas.SecurityGuard.Controllers
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
            var viewModel = _memberService.GetRanks();

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

        public ActionResult Details(int id)
        {
            var viewModel = _memberService.ReadUser(id);
            

            return View("Details", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _memberService.Read(id);

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(EditMemberViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _memberService.EditUser(viewModel);

                return RedirectToAction("Index");
            }

            return View("Edit");
        }
    }
}
