//-------------------------------------------------------------------------------
// <copyright file="DatabaseRepository.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Service.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using SurveyCat.Service.Models;

    /// <summary>
    /// The DatabaseRepository
    /// </summary>
    /// <seealso cref="SurveyCat.Service.Repository.IDatabaseRepository" />
    public class DatabaseRepository : IDatabaseRepository
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The con string
        /// </summary>
        private string conString = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DatabaseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.conString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Adds the survey.
        /// </summary>
        /// <param name="surveyModel">The survey model.</param>
        public void AddSurvey(Survey surveyModel)
        {
            using (IDbConnection connection = new SqlConnection(this.conString))
            {
                connection.Query($"INSERT INTO [Survey] ([Rating],[Comment],[ProductId]) VALUES(@Rating, @Comment, @ProductId);", surveyModel);
            }
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns> Returns list of brands </returns>
        public List<Brand> GetBrands()
        {
            using (IDbConnection connection = new SqlConnection(this.conString))
            {
                return connection.Query<Brand>($"SELECT * FROM [Brand]").ToList();
            }
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="brand">The brand identifier.</param>
        /// <returns> Returns list of products </returns>
        public List<Product> GetProducts(Guid brand)
        {     
            using (IDbConnection connection = new SqlConnection(this.conString))
            {
                return connection.Query<Product>($"SELECT * FROM [Product] WHERE [BrandId] = '{brand}'").ToList();
            }
        }

        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <returns> Returns list of reports </returns>
        public List<Report> GetReport()
        {
            using (IDbConnection connection = new SqlConnection(this.conString))
            {              
                return connection.Query<Report>($"SELECT * FROM v_Report").ToList();                          
            }
        }
    }
}
