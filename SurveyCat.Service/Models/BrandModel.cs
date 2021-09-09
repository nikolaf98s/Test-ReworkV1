using System;
using Dapper.Contrib.Extensions;

namespace SurveyCat.Service.Models
{
    [Table("[Brand]")]
    public class BrandModel
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string BrandName { get; set; }

    }
}
