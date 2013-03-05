using System.Collections.Generic;
using SecurityGuard.Services;

namespace CadetCorps.ViewModels
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