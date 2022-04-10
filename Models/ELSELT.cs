using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("ELSELT")]
    public class ELSELT
    {
        public decimal ID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public decimal? AGE { get; set; }
        public decimal? HEIGHT { get; set; }
        public decimal? WEIGHT { get; set; }
        public string EMAIL { get; set; }  
        public string PHONENUMBER { get; set; }
        public string ADDRESS{ get; set; }
        public decimal? MALE { get; set; }
        public string RDNUMBER { get; set; }
        public string RELATION { get; set; }
        public string RELATIONNAME { get; set; }
        public string RELATIONPHONENUMBER { get; set; }
        public string DISTRICT { get; set; }
        

    }
}

