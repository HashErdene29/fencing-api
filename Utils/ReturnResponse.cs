using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Utils
{
    public class ReturnResponse
    {
        public static ResponseClient ObjectResult(object value, string message = "Амжилттай")
        {
            ResponseClient response = new ResponseClient();
            response.Message = message;
            response.Data = value;
            response.Success = true;
            response.RowCount = RowCount(value);
            return response;
        }

        public static ResponseClient InvalidResult(object value, string message = "Амжилтгүй", bool data = true, decimal code = 0)
        {
            ResponseClient response = new ResponseClient();
            response.Message = message;

            if (data)
                response.Data = value;
            else
                response.Value = value;

            response.Code = code;
            response.Success = false;
            return response;
        }
        public static ResponseClient NotFoundResult()
        {
            ResponseClient response = new ResponseClient();
            response.Message = "Таны хүсэлтэнд өгөгдөл олдсонгүй";
            response.Success = false;
            return response;
        }
        private static int RowCount(object o)
        {
            return IsList(o) ? ((o is IList) ? (o as IList).Count : 0) : 0;
        }
        private static bool IsList(object o)
        {
            return o != null
                //&& o is IList 
                && o.GetType().IsGenericType
                && (o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>))
                || o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(IEnumerable<>)));
        }

        internal static ResponseClient SuccessResponse()
        {
            throw new NotImplementedException();
        }
    }
}
