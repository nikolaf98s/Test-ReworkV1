using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyCat.Service.Models;

namespace SurveyCat.Service.Repository
{
    public interface IDatabaseRepository
    {
        public List<ProductModel> GetProducts(Guid brendId);
        public List<BrandModel> GetBrands();
        public void AddSurvey(SurveyModel surveyModel);
        public List<ReportModel> GetReport();
    }
}
