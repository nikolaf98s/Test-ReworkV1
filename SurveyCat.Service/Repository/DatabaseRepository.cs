using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SurveyCat.Service.Models;
using Dapper;
using Microsoft.Extensions.Configuration;




namespace SurveyCat.Service.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IConfiguration configuration;
        string conString = "";

        public DatabaseRepository(IConfiguration _configur)
        {
            configuration = _configur;
            conString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddSurvey(SurveyModel surveyModel)
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {                
                connection.Query(@$"INSERT INTO [Survey] ([Rating],[Comment],[ProductId]) VALUES({surveyModel.Rating},'{surveyModel.Comment}','{surveyModel.ProductId}');");             
            }
        }

        public List<BrandModel> GetBrands()
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {
                return  connection.Query<BrandModel>(@$"SELECT * FROM [Brand]").ToList();
            }
        }

        public List<ProductModel> GetProducts(Guid brendId)
        {     
            using (IDbConnection connection = new SqlConnection(conString))
            {
                return  connection.Query<ProductModel>(@$"SELECT * FROM [Product] WHERE [BrandId] = '{brendId}'").ToList();
            }
        }

        public List<ReportModel> GetReport()
        {
            using (IDbConnection connection = new SqlConnection(conString))
            {              
                return connection.Query<ReportModel>(@$"SELECT * FROM v_Report").ToList();                          
            }
        }
    }
}
