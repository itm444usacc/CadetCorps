using System.Web.Mvc;
using CadetCorps.Areas.SecurityGuard.ViewModels.Members;
using CadetCorps.Core.Interfaces;

namespace CadetCorps.Areas.SecurityGuard.Controllers
{
    public class MembersController : Controller
    {
        /*  ---The Members Controller calls the MembersSerive for queries and MySQL Posts.
         *  All Views are in the Areas/Members/View Folder, Areas/ViewModels in the ViewModel folder. Models
         *  are within the Core folder and are currently a 1 to 1 match with the db---  */


        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /*  ---Gets list of members via Members Service, displays on Index page---  */
        public ActionResult Index()
        {
            var list = _memberService.GetMembersList();

            return View("Index", list);
        }

        /*  ---Gets new CreateMembersViewModel and grabs ranks Members Service, displays on Create page---  */
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = _memberService.GetRanks();

            return View("Create", viewModel);
        }

        /*  ---Posts CreateMembersViewModel via Members Service, redirects to Index page---  */
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

        /*  ---Shows Member info using Members Service, displays on Details page---  */
        public ActionResult Details(int id)
        {
            var viewModel = _memberService.ReadUser(id);
            

            return View("Details", viewModel);
        }

        /*  ---Edit Member info using Members Service, displays on Edit page---  */
        public ActionResult Edit(int id)
        {
            var viewModel = _memberService.Read(id);

            return View("Edit", viewModel);
        }

        /*  ---Posts edited Member info using Members Service, redirects to Index page---  */
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
