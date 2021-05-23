using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Models.CategoryModels
{
    public class CategoryModel
    {
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public decimal? CONTRACTID { get; set; }
        public string CONTRACTNM { get; set; }
        public DateTime? INSYMD { get; set; }
    }
}
