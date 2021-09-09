using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SurveyCat.Service.Models
{
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
