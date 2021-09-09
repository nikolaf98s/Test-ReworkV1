using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCat.Air.Entities
{
    public class Survey
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid ProductId { get; set; }

        public Survey()
        {

        }
        public Survey(int rating, string comment, Guid productId)
        {
            this.Rating = rating;
            this.Comment = comment;
            this.ProductId = productId;
        }
    }
}
