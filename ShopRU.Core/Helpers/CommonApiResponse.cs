using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Core.Helpers
{
    public class CommonApiResponse
    {
        public static CommonApiResponse Create(HttpStatusCode statusCode, object result = null, string errorMessage = null)
        {
            return new CommonApiResponse(statusCode, result, errorMessage);
        }

        [JsonProperty("version")]
        public static string Version => "1";

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }

        protected CommonApiResponse(HttpStatusCode statusCode, object result = null, string errorMessage = null)
        {
            RequestId = Guid.NewGuid().ToString();
            StatusCode = (int)statusCode;
            Result = result;
            try
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    ErrorMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $" {errorMessage}";
            }
        }
    }
}