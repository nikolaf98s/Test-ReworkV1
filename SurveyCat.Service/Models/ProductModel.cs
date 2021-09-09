using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace SurveyCat.Service.Models
{
    [Table("[Product]")]
    public class ProductModel
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid BrandId { get; set; }

    }
}
