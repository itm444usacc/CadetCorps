using CadetCorps.Areas.SecurityGuard.ViewModels.Contacts;

namespace CadetCorps.Core.Interfaces
{
    public interface IContactsService
    {
        void CreateUser(CreateContactsViewModel viewModel);

        EditCreateViewModel GetContacts(int id);
    }
}