//-------------------------------------------------------------------------------
// <copyright file="Survey.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Air.Entities
{
    using System;

    /// <summary>
    /// The Survey
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Survey"/> class.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="productId">The product identifier.</param>
        public Survey(int rating, string comment, Guid productId)
        {
            this.Rating = rating;
            this.Comment = comment;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }
    }
}
