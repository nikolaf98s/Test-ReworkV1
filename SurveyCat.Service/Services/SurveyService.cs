
namespace SurveyCat.Service.Services
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;
    using SurveyCat.Service.Repository;

    public class SurveyService : ISurveyService
    {
        private IDatabaseRepository repository;

        public SurveyService(IDatabaseRepository repository)
        {
            this.repository = repository;
        }

        public void AddSurvey(Survey surveyModel)
        {
            repository.AddSurvey(surveyModel);
        }

        public List<Brand> GetBrands()
        {
            return repository.GetBrands();
        }

        public List<Product> GetProducts(Guid brandId)
        {
            return repository.GetProducts(brandId);  
        }

        public List<Report> GetReport()
        {
            return repository.GetReport();
        }
    }
}
