
namespace SurveyCat.Service.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using SurveyCat.Service.Models;
    using Dapper;
    using Microsoft.Extensions.Configuration;

    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IConfiguration configuration;
        string conString = "";

        public DatabaseRepository(IConfiguration _configur)
        {
            configuration = _configur;
            conString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddSurvey(Survey surveyModel)
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {                
                connection.Query(@$"INSERT INTO [Survey] ([Rating],[Comment],[ProductId]) VALUES({surveyModel.Rating},'{surveyModel.Comment}','{surveyModel.ProductId}');");             
            }
        }

        public List<Brand> GetBrands()
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {
                return  connection.Query<Brand>(@$"SELECT * FROM [Brand]").ToList();
            }
        }

        public List<Product> GetProducts(Guid brendId)
        {     
            using (IDbConnection connection = new SqlConnection(conString))
            {
                return  connection.Query<Product>(@$"SELECT * FROM [Product] WHERE [BrandId] = '{brendId}'").ToList();
            }
        }

        public List<Report> GetReport()
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {              
                return connection.Query<Report>(@$"SELECT * FROM v_Report").ToList();                          
            }
        }
    }
}
