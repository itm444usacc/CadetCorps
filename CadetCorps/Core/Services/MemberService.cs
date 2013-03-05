using System.Configuration;
using System.Linq;
using CadetCorps.Core.Interfaces;
using CadetCorps.ViewModels;
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
                var query = cmd.CommandText = "SELECT Id, FirstName, LastName, Username FROM cadtrak.Members";


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
                var query = cmd.CommandText = "SELECT Id, FirstName, MiddleName, LastName, NickName, Username, Comments, Email, Expired, Created, TrainingPlansId" +
                                              "FROM cadtrak.Members" +
                                              "WHERE Id = @Id";

                result = connection.Query<EditMemberViewModel>(query, new { id }).FirstOrDefault();
            }
            return result;
        }


        public void CreateUser(CreateMemberViewModel viewModel)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = "INSERT INTO cadtrak.Members( FirstName, MiddleName, LastName, NickName, Username, Comments, Email, Expired, Created, TrainingPlansId) VALUES ( @FirstName, @MiddleName, @LastName, @NickName, @Username, @Comments, @Email, @Expired, @Created, @TrainingPlansId)";
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
                    viewModel.TrainingPlansId
                });
                connection.Close();
            }
        }

        public void Edit(EditMemberViewModel viewModel)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = "UPDATE cadtrak.Members " +
                                              "SET FirstName = FirstName, MiddleName = @MiddleName, LastName = @LastName, NickName = @NickName, Username = @Username, Comments = @Comments, Email = @Email, Expired = @Expired, Created = @Created, TrainingPlansId = TrainingPlansId " +
                                              "WHERE Id = @Id";
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
                connection.Close();
            }
        }
    }
}
