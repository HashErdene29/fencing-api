using NewsApi.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Models.AuthModels
{
    public class RegisterModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public decimal phoneno { get; set; }
        public string password { get; set; }
    }
}
