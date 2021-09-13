//-------------------------------------------------------------------------------
// <copyright file="Brand.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Service.Models
{
    using System;
    using Dapper.Contrib.Extensions;

    /// <summary>
    /// The Brand
    /// </summary>
    [Table("[Brand]")]
    public class Brand
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [ExplicitKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
