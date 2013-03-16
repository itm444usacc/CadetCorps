
namespace CadetCorps.Areas.SecurityGuard.ViewModels.Contacts
{
    public class CreateContactsViewModel
    {
        public int Id { get; set; }
        public int MembersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
    }
}