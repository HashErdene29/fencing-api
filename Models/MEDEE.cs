using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("MEDEE")]
    public class MEDEE
    {
        public decimal ID { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string FEATURETXT { get; set; }
        public string IMAGE { get; set; }
    }
}