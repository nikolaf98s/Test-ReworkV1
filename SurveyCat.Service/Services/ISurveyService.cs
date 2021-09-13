//-------------------------------------------------------------------------------
// <copyright file="ISurveyService.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Service.Services
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;

    /// <summary>
    /// The ISurveyService
    /// </summary>
    public interface ISurveyService
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="brandId">The brand identifier.</param>
        /// <returns> List of Products </returns>
        public List<Product> GetProducts(Guid brandId);

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns> List of Brands </returns>
        public List<Brand> GetBrands();

        /// <summary>
        /// Adds the survey.
        /// </summary>
        /// <param name="surveyModel">The survey model.</param>
        public void AddSurvey(Survey surveyModel);

        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <returns> Returns Report </returns>
        public List<Report> GetReport();     
    }
}
