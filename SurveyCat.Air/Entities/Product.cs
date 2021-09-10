
namespace SurveyCat.Air.Entities
{
    using System;

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BrandId { get; set; }
    }
}
