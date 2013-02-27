using System.Web.Mvc;

namespace CadetCorps.Areas.SecurityGuard.ViewModels
{
    public class ManageRolesViewModel
    {
        public SelectList Roles { get; set; }
        public string[] RoleList { get; set; }
    }
}
