
namespace SurveyCat.Service.Services
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;

    public interface ISurveyService
    {
        public List<ProductModel> GetProducts(Guid brandId);
        public List<BrandModel> GetBrands();
        public void AddSurvey(SurveyModel surveyModel);
        public List<ReportModel> GetReport();
        
    }
}
