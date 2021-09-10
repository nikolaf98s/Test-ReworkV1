
namespace SurveyCat.Service.Models
{
    using System;
    using Dapper.Contrib.Extensions;

    [Table("[Product]")]
    public class ProductModel
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid BrandId { get; set; }

    }
}
