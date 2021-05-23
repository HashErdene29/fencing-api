using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("JOB")]
    public class JOB
    {
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public decimal CATID { get; set; }
        public decimal? USERID { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public string TYPE { get; set; }
        public bool ISDEAL { get; set; }
        public DateTime? INSYMD { get; set; }
        public DateTime? UPDYMD { get; set; }
        public string CVALUE { get; set; }
    }
}
