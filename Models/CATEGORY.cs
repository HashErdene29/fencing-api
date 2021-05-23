using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("CATEGORY")]
    public class CATEGORY
    {
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public decimal? CONTRACTID { get; set; }
        public string CONTRACTNM { get; set; }
        public DateTime? INSYMD { get; set; }
        public string IMAGE { get; set; }
        public string CONTRACTFILE { get; set; }
    }
}
