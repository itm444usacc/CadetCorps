using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CadetCorps.Areas.SecurityGuard.ViewModels.Contacts;
using CadetCorps.Areas.SecurityGuard.ViewModels.Members;
using CadetCorps.Core.Interfaces;
using CadetCorps.Core.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace CadetCorps.Core.Services
{
    public class ContactsService : IContactsService
    {
        public void CreateUser(CreateContactsViewModel viewModel)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();

                var query = cmd.CommandText = @"INSERT INTO cadtrak.Contacts( FirstName, LastName, PhoneNumber, Address, State, City, Zip, Email, MembersId, Relationship ) 
                                                VALUES ( @FirstName, @LastName, @PhoneNumber, @Address, @State, @City, @Zip, @Email, @MembersId, @Relationship)";
                connection.Execute(query, new
                {
                    viewModel.FirstName,
                    viewModel.LastName,
                    viewModel.PhoneNumber,
                    viewModel.Address,
                    viewModel.State,
                    viewModel.City,
                    viewModel.Zip,
                    viewModel.Email,
                    viewModel.Relationship,
                    viewModel.MembersId
                });
            }
        }

        public EditCreateViewModel GetContacts(int id)
        {
            EditCreateViewModel result;

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();

                var query = cmd.CommandText = @"SELECT * FROM cadtrak.contacts WHERE Id = @id";
                result = connection.Query<EditCreateViewModel>(query, new { id }).SingleOrDefault();


                return result;

            }

            
        }
    }
}