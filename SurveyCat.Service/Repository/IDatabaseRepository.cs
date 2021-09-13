//-------------------------------------------------------------------------------
// <copyright file="IDatabaseRepository.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Service.Repository
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;

    /// <summary>
    /// The IDatabaseRepository
    /// </summary>
    public interface IDatabaseRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="brand">The brand identifier.</param>
        /// <returns> Returns list of products </returns>
        public List<Product> GetProducts(Guid brand);

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns> Returns list of brand </returns>
        public List<Brand> GetBrands();

        /// <summary>
        /// Adds the survey.
        /// </summary>
        /// <param name="surveyModel">The survey model.</param>
        public void AddSurvey(Survey surveyModel);

        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <returns> Returns report </returns>
        public List<Report> GetReport();
    }
}
