using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace ShopRU.Core.Helpers
{
    public class ErrorResponse
    {
        [JsonProperty("error_description")]
        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; } = "An error  occured, try again later.";

        public static ErrorResponse GetModelStateErrors(ValueEnumerable errors)
        {
            var message = string.Join(" | ", errors
                               .SelectMany(v => v.Errors)
                               .Select(e => e.ErrorMessage));
            return new ErrorResponse { ErrorDescription = !string.IsNullOrEmpty(message) ? message : "Fill required values" };
        }
    }
}