
namespace SurveyCat.Service.Models
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("[Product]")]
    public class Product
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BrandId { get; set; }

    }
}
