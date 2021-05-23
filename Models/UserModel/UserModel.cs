using NewsApi.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Models.UserModels
{
    public class UserModel
    {
        public decimal ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public Enum.Role ROLE { get; set; }
        public string IMAGE { get; set; }
        public decimal PHONENO { get; set; }
        public string ADDRESS { get; set; }
        public string REGISTRNO { get; set; }
        public DateTime? INSYMD { get; set; }
        public DateTime? UPDYMD { get; set; }
    }
}
