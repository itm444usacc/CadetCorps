using System.ComponentModel.DataAnnotations;

namespace CadetCorps.Areas.SecurityGuard.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage="RoleName is required.")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
