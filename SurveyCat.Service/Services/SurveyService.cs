using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SurveyCat.Service.Models;
using SurveyCat.Service.Repository;

namespace SurveyCat.Service.Services
{
    public class SurveyService : ISurveyService
    {
        private IDatabaseRepository repository;

        public SurveyService(IDatabaseRepository repository)
        {
            this.repository = repository;
        }

        public void AddSurvey(SurveyModel surveyModel)
        {
            repository.AddSurvey(surveyModel);
        }

        public List<BrandModel> GetBrands()
        {
            return repository.GetBrands();
        }

        public List<ProductModel> GetProducts(Guid brandId)
        {
            return repository.GetProducts(brandId);  
        }

        public List<ReportModel> GetReport()
        {
            return repository.GetReport();
        }
    }
}
