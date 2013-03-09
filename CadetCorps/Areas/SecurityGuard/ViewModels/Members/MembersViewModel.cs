using System.Collections.Generic;

namespace CadetCorps.Areas.SecurityGuard.ViewModels.Members
{

    public class ListMembersViewModel
    {
        public List<MembersViewModel> Members { get; set; }
    }

    public class MembersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}