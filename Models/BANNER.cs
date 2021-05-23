using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("BANNER")]
    public class BANNER
    {
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public string IMG { get; set; }
    }
}
