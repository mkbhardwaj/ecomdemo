using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiException:ApiResponse
    {
        public string Details { set; get; }
        public ApiException(int statusCode, string message,string details=null) : base(statusCode, message) {
            this.Details = details;
        }
    }
}
