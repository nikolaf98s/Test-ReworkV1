
namespace SurveyCat.Service.Services
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;

    public interface ISurveyService
    {
        public List<Product> GetProducts(Guid brandId);
        public List<Brand> GetBrands();
        public void AddSurvey(Survey surveyModel);
        public List<Report> GetReport();
        
    }
}
