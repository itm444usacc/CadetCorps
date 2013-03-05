using CadetCorps.ViewModels;

namespace CadetCorps.Core.Interfaces
{
    public interface IMemberService
    {

        ListMembersViewModel GetMembersList();

        EditMemberViewModel Read(int id);

        void CreateUser(CreateMemberViewModel viewModel);

        void Edit(EditMemberViewModel viewModel);
    }
}