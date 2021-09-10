
namespace SurveyCat.Service.Repository
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;

    public interface IDatabaseRepository
    {
        public List<ProductModel> GetProducts(Guid brendId);
        public List<BrandModel> GetBrands();
        public void AddSurvey(SurveyModel surveyModel);
        public List<ReportModel> GetReport();
    }
}
