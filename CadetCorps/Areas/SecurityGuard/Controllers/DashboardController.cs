using System.Web.Mvc;
using System.Web.Security;
using CadetCorps.Areas.SecurityGuard.ViewModels;
using CadetCorps.Controllers;
using SecurityGuard.Interfaces;
using SecurityGuard.Services;

namespace CadetCorps.Areas.SecurityGuard.Controllers
{
    [Authorize(Roles = "SecurityGuard")]
    public class DashboardController : BaseController
    {

        #region ctors

        private readonly IMembershipService _membershipService;
        private readonly IRoleService _roleService;

        public DashboardController()
        {
            _roleService = new RoleService(Roles.Provider);
            _membershipService = new MembershipService(Membership.Provider);
        }

        #endregion


        public virtual ActionResult Index()
        {
            var viewModel = new DashboardViewModel();
            int totalRecords;

            _membershipService.GetAllUsers(0, 20, out totalRecords);
            viewModel.TotalUserCount = totalRecords.ToString();
            viewModel.TotalUsersOnlineCount = _membershipService.GetNumberOfUsersOnline().ToString();
            viewModel.TotalRolesCount = _roleService.GetAllRoles().Length.ToString();

            return View(viewModel);
        }

    }
}
