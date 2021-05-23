using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("USER")]
    public class USER
    {
        public decimal ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string CVALUE { get; set; }
        public string PASSWORD { get; set; }
        public string FCMTOKEN { get; set; }
        public Enum.Role ROLE { get; set; }
        public string IMAGE { get; set; }
        public decimal PHONENO { get; set; }
        public string ADDRESS { get; set; }
        public string REGISTRNO { get; set; }
        public DateTime? INSYMD { get; set; }
        public DateTime? UPDYMD { get; set; }
    }
}
