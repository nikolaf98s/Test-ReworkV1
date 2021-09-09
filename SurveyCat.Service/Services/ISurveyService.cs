using System;
using System.Collections.Generic;
using SurveyCat.Service.Models;

namespace SurveyCat.Service.Services
{
    public interface ISurveyService
    {
        public List<ProductModel> GetProducts(Guid brandId);
        public List<BrandModel> GetBrands();
        public void AddSurvey(SurveyModel surveyModel);
        public List<ReportModel> GetReport();
        
    }
}
