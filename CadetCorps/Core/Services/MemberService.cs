using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CadetCorps.Areas.SecurityGuard.ViewModels.Members;
using CadetCorps.Core.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace CadetCorps.Core.Services
{
    public class MemberService : IMemberService
    {
        public ListMembersViewModel GetMembersList()
        {
            var viewModel = new ListMembersViewModel();

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = @"SELECT Id, FirstName, LastName, Username FROM cadtrak.Members";


                var result = connection.Query<MembersViewModel>(query, new { }).ToList();
                viewModel.Members = result;
            }
            return viewModel;
        }

        public EditMemberViewModel Read(int id)
        {
            EditMemberViewModel result;

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = @"SELECT Id, FirstName, MiddleName, LastName, NickName, Username, Comments, Email, Expired, Created, TrainingPlansId FROM Members WHERE Id = @id";

                result = connection.Query<EditMemberViewModel>(query, new { id }).FirstOrDefault();
            }
            return result;
        }

        public MemberDetailsViewModel ReadUser(int id)
        {
            MemberDetailsViewModel result;

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var memberQuery = cmd.CommandText = @"SELECT Id, FirstName, MiddleName, LastName, NickName, Username, Comments, Email, Expired, Created, TrainingPlansId FROM Members WHERE Id = @id";

                var contactQuery = cmd.CommandText = @"SELECT * FROM cadtrak.contacts WHERE MembersId = @id";

                result = connection.Query<MemberDetailsViewModel>(memberQuery, new { id }).FirstOrDefault();

                if (result != null)
                    result.Contacts = connection.Query<ContactsViewModel>(contactQuery, new { id }).ToList();
            }

             return result;
        }

        public CreateMemberViewModel GetRanks()
        {
            var viewModel = new CreateMemberViewModel();

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = @"SELECT Id AS RankId, Nomen, Rank FROM serviceinformationgradestypes";

                var con = connection.Query(query).ToList();

                var ranks = con.Select(item => new SelectListItem { Text = item.Nomen, Value = item.RankId.ToString() }).ToList();

                viewModel.Rank = ranks;
            }

            return viewModel;
        }

        public void CreateUser(CreateMemberViewModel viewModel)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                viewModel.Created = DateTime.Now;
                viewModel.Expired = DateTime.Now.AddYears(1);
                connection.Open();

                var query = cmd.CommandText = @"INSERT INTO cadtrak.Members( FirstName, MiddleName, LastName, SocialSecurity, NickName, Username, Comments, Email, Expired, Created, Admin, TrainingPlansId) 
                                                VALUES ( @FirstName, @MiddleName, @LastName, @SocialSecurity, @NickName, @Username, @Comments, @Email, @Expired, @Created, @Admin, @TrainingPlansId)";
                connection.Execute(query, new
                {
                    viewModel.FirstName,
                    viewModel.MiddleName,
                    viewModel.LastName,
                    viewModel.SocialSecurity,
                    viewModel.Nickname,
                    viewModel.Username,
                    viewModel.Comments,
                    viewModel.Email,
                    viewModel.Expired,
                    viewModel.Created,
                    viewModel.Admin,
                    viewModel.TrainingPlansId
                });
            }
        }

        public void EditUser(EditMemberViewModel viewModel)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = @"UPDATE cadtrak.Members 
                                                SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, NickName = @NickName, 
                                                    Username = @Username, Comments = @Comments, Email = @Email, Expired = @Expired, Created = @Created, TrainingPlansId = TrainingPlansId WHERE Id = @Id";
                connection.Execute(query, new
                {
                    viewModel.FirstName,
                    viewModel.MiddleName,
                    viewModel.LastName,
                    viewModel.Nickname,
                    viewModel.Username,
                    viewModel.Comments,
                    viewModel.Email,
                    viewModel.Expired,
                    viewModel.Created,
                    viewModel.TrainingPlansId,
                    id = viewModel.Id
                });
            }
        }
    }
}
