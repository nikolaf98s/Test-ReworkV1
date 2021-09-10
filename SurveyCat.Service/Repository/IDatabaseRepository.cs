
namespace SurveyCat.Service.Repository
{
    using System;
    using System.Collections.Generic;
    using SurveyCat.Service.Models;

    public interface IDatabaseRepository
    {
        public List<Product> GetProducts(Guid brendId);
        public List<Brand> GetBrands();
        public void AddSurvey(Survey surveyModel);
        public List<Report> GetReport();
    }
}
