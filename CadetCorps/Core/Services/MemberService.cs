using System.Configuration;
using CadetCorps.Core.Interfaces;
using CadetCorps.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace CadetCorps.Core.Services
{
    public class MemberService : IMemberService
    {
        
        public void CreateUser(CreateMemberViewModel viewModel)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = "INSERT INTO cadtrak.Members( FirstName, MiddleName, LastName, NickName, Username, Comments, Email, Expired, Created, TrainingPlansId) VALUES ( @FirstName, @MiddleName, @LastName, @NickName, @Username, @Comments, @Email, @Expired, @Created, @TrainingPlan";

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
                    viewModel.TrainingPlan
                });
            }
        }
    }
}
//INSERT INTO cadtrak.Members( FirstName, MiddleName, LastName, NickName, Username, Comments, Email, Expired, Created, TrainingPlansId) VALUES ( 'Gary', 'Michael', 'James', 'Havoc', 'jamesga1', 'meow', 'a@a.com', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1 )