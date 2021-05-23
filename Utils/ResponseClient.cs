using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Utils
{
    public class ResponseClient
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int RowCount { get; set; }
        public object Value { get; set; }
        public decimal? Code { get; set; }
    }
}
