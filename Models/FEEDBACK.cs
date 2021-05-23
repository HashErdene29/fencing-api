using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("FEEDBACK")]
    public class FEEDBACK
    {
        public decimal ID { get; set; }
        public decimal JOBID { get; set; }
        public decimal USERID { get; set; }
        public decimal ORDERID { get; set; }
        public decimal RATING { get; set; }
        public string COMMENT { get; set; }
        public bool ISHIDE { get; set; }
        public DateTime? INSYMD { get; set; }
        public DateTime? UPDYMD { get; set; }
    }
}
