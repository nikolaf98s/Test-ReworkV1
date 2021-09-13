//-------------------------------------------------------------------------------
// <copyright file="SurveyService.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Service.Services
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;
    using SurveyCat.Service.Repository;

    /// <summary>
    /// The SurveyService
    /// </summary>
    /// <seealso cref="SurveyCat.Service.Services.ISurveyService" />
    public class SurveyService : ISurveyService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IDatabaseRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public SurveyService(IDatabaseRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the survey.
        /// </summary>
        /// <param name="surveyModel">The survey model.</param>
        public void AddSurvey(Survey surveyModel)
        {
            this.repository.AddSurvey(surveyModel);
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns>
        /// List of Brands
        /// </returns>
        public List<Brand> GetBrands()
        {
            return this.repository.GetBrands();
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="brand">The brand identifier.</param>
        /// <returns>
        /// List of Products
        /// </returns>
        public List<Product> GetProducts(Guid brand)
        {
            return this.repository.GetProducts(brand);  
        }

        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <returns>
        /// Returns Report
        /// </returns>
        public List<Report> GetReport()
        {
            return this.repository.GetReport();
        }
    }
}
