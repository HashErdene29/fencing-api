using NewsApi.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Models.CategoryModels
{
    public class CreateOrderModel
    {
        public decimal userid { get; set; }
        public decimal catid { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public decimal jobid { get; set; }
    }
}
