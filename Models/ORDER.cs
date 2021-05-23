using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("ORDER")]
    public class ORDER
    {
        public decimal ID { get; set; }
        public decimal USERID { get; set; }
        public decimal? JOBID { get; set; }
        public decimal? CATID { get; set; }
        public DateTime? DATE { get; set; }
        public DateTime? INSYMD { get; set; }
        public DateTime? UPDYMD { get; set; }
        public Enum.Status STATUS { get; set; }
        public string IMG { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
