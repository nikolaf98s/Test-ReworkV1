
namespace SurveyCat.Service.Models
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("[Brand]")]
    public class Brand
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
