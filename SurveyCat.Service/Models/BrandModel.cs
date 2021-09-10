
namespace SurveyCat.Service.Models
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("[Brand]")]
    public class BrandModel
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string BrandName { get; set; }

    }
}
