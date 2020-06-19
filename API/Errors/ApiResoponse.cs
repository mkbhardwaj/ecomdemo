using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { set; get; }
        public string Message { set; get; }
        public ApiResponse(int statusCode, string message=null)
        {
            this.StatusCode = statusCode;
            this.Message = string.IsNullOrEmpty(message) ? GetDefaultMessageForStatus(statusCode): message;
        }

        private string GetDefaultMessageForStatus(int statusCode)
        {
            string message = null;
            switch (statusCode)
            {
                case 400:
                    message = "Very bad request.";
                    break;
                case 401:
                    message = "Not at all authorize.";
                    break;
                case 404:
                    message = "Resource not found.";
                    break;
                case 500:
                    message = "Internal server error !";
                    break;
                default:
                    message = null;
                    break;
            }
            return message;

        }
    }
}
