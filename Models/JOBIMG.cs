using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsApi.Enum;

namespace NewsApi.Models
{
    [Table("JOBIMG")]
    public class JOBIMG
    {
        public decimal ID { get; set; }
        public decimal? JOBID { get; set; }
        public string IMG { get; set; }
        public decimal CATID { get; set; }
    }
}