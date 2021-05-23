using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Models.UserModels
{
    public class UserVerify
    {
        public decimal? userid { get; set; }
        public decimal catid { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }

    }
}
