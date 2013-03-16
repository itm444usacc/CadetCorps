using CadetCorps.Areas.SecurityGuard.ViewModels.Members;

namespace CadetCorps.Core.Interfaces
{
    public interface IMemberService
    {

        ListMembersViewModel GetMembersList();

        EditMemberViewModel Read(int id);

        MemberDetailsViewModel ReadUser(int id);

        CreateMemberViewModel GetRanks();

        void CreateUser(CreateMemberViewModel viewModel);

        void EditUser(EditMemberViewModel viewModel);
    }
}