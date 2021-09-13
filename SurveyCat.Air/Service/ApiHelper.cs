//-------------------------------------------------------------------------------
// <copyright file="ApiHelper.cs" company="SoftLab">
//     Copyright (c) www.softlab.rs. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SurveyCat.Air.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows;
    using Newtonsoft.Json;
    using SurveyCat.Air.Entities;

    /// <summary>
    /// The API Helper
    /// </summary>
    public class ApiHelper
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static ApiHelper instance = null;

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public static string BaseUrl { get; set; } = "https://localhost:5001/Survey/";

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ApiHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiHelper();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>
        /// The API client.
        /// </value>
        public HttpClient ApiClient { get; set; }

        /// <summary>
        /// Initializes the client.
        /// </summary>
        public void InitializeClient()
        {
            this.ApiClient = new HttpClient();
            this.ApiClient.BaseAddress = new Uri(BaseUrl);
            this.ApiClient.DefaultRequestHeaders.Accept.Clear();
            this.ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns> List of brands </returns>
        public async Task<List<Brand>> GetBrands()
        {           
            using (this.ApiClient)
            {
                try
                {
                    var response = await this.ApiClient.GetAsync($"{BaseUrl}brands");
                    if (response.IsSuccessStatusCode == true)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Brand>>(content);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error with geting brand data!!!");
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="brandId">The brand identifier.</param>
        /// <returns> List of products </returns>
        public async Task<List<Product>> GetProducts(Guid brandId)
        {
            this.InitializeClient();
            List<Product> products = new List<Product>();
            using (this.ApiClient)
            {
                try
                {
                    var response = await this.ApiClient.GetAsync(BaseUrl + "products?brandId=" + brandId);

                    if (response.IsSuccessStatusCode == true)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<Product>>(content);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error with geting product data!!!");
                }   
            }

            return products;
        }

        /// <summary>
        /// Posts the survey.
        /// </summary>
        /// <param name="survey">The survey.</param>
        /// <returns> Post survey </returns>
        public async Task PostSurvey(Survey survey)
        {
            this.InitializeClient();
            using (this.ApiClient)
            {
                try
                {
                    HttpResponseMessage response = await this.ApiClient.PostAsJsonAsync($"{BaseUrl}survey", survey);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error with sending survey!!!");
                    return;
                }

                MessageBox.Show("Survey Sent!!!");
            }
        }
    }
}
