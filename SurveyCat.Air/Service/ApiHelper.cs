
namespace SurveyCat.Air.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using SurveyCat.Air.Entities;
    using Newtonsoft.Json;
    using System.Windows;

    public class ApiHelper
    {
        public static ApiHelper instance = null;
        public HttpClient ApiClient { get; set; }
        public static string BaseUrl { get; set; } = "https://localhost:5001/Survey/";

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
        public void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(BaseUrl);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Brand>> GetBrands()
        {          
            
            using (ApiClient)
            {
                try
                {
                    var response = await ApiClient.GetAsync($"{BaseUrl}brands");
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
        public async Task<List<Product>> GetProducts(Guid brandId)
        {
            InitializeClient();
            List<Product> products = new List<Product>();
            using (ApiClient)
            {
                try
                {
                    var response = await ApiClient.GetAsync(BaseUrl + "products?brandId=" + brandId);

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
        public async Task PostSurvey(Survey survey)
        {
            InitializeClient();
            using (ApiClient)
            {
                try
                {
                    HttpResponseMessage response = await ApiClient.PostAsJsonAsync($"{BaseUrl}survey", survey);
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
