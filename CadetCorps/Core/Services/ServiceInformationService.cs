﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CadetCorps.Core.Interfaces;
using CadetCorps.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace CadetCorps.Core.Services
{
    public class ServiceInformationService : IServiceInformationService
    {
        public ServiceInformationGrades GetServiceInformation()
        {
            var viewModel = new ServiceInformationGrades();

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                var query = cmd.CommandText = " ";


                var result = connection.Query<ServiceInformationGrades>(query, new { }).ToList();

            }
            return viewModel;
        }
    }
}