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
                var query = cmd.CommandText = "INSERT INTO Members( FirstName, MiddleName, LastName, NickName, Username, Comments, Email) VALUES ( @FirstName, @MiddleName, @LastName, @NickName, @Username, @Comments, @Email ";

                connection.Execute(query, new
                {
                    viewModel.FirstName,
                    viewModel.MiddleName,
                    viewModel.LastName,
                    viewModel.Username,
                    viewModel.Comments,
                    viewModel.Email,
                });
            }
        }
    }
}