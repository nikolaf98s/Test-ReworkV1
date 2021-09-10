
namespace SurveyCat.Service.Models
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("[Survey]")]
    public class SurveyModel
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public Guid ProductId { get; set; }

       
    }
}
