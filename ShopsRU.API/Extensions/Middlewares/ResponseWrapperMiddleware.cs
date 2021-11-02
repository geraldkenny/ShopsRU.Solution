using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShopRU.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShopsRU.API.Extensions.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var currentBody = context.Response.Body;

            using var memoryStream = new MemoryStream();
            //set the current response to the memorystream.
            context.Response.Body = memoryStream;

            await _next(context);

            //reset the body
            context.Response.Body = currentBody;
            memoryStream.Seek(0, SeekOrigin.Begin);

            using var streamReader = new StreamReader(memoryStream);
            var readToEnd = streamReader.ReadToEnd();
            var objResult = JsonConvert.DeserializeObject(readToEnd);

            try
            {
                if ((HttpStatusCode)context.Response.StatusCode != HttpStatusCode.OK)
                {
                    string[] errorArray = readToEnd?.Split(',');
                    if (errorArray.Length >= 4 && errorArray?[4] != null && (bool)errorArray?[4]?.StartsWith("\"errors\""))
                    {
                        var jsonError = JsonConvert.DeserializeObject<ValidationModelError>(readToEnd);

                        var errors = string.Join(" | ", jsonError.Errors
                                  .SelectMany(v => v.Value));

                        await WriteResponseAsync(context, null, errors);
                    }
                    else if (!string.IsNullOrEmpty(readToEnd))
                    {
                        try
                        {
                            var jsonError = JsonConvert.DeserializeObject<ErrorResponse>(readToEnd);
                            await WriteResponseAsync(context, null, jsonError.ErrorDescription);
                        }
                        catch (Exception)
                        {
                            if (errorArray.Length > 0 && errorArray?[0] != null && !string.IsNullOrEmpty(errorArray?[0]))
                            {
                                var error = errorArray[0];
                                await WriteResponseAsync(context, null, error);
                            }
                        }
                    }
                }
                else
                {
                    await WriteResponseAsync(context, objResult);
                }
            }
            catch (Exception ex)
            {
                var response = new ErrorResponse
                {
                    ErrorDescription = $"{ex.Message} ||  {ex.StackTrace}"
                };
                await WriteResponseAsync(context, objResult, JsonConvert.SerializeObject(response));
            }
        }

        private static async Task WriteResponseAsync(HttpContext context, object result = null, string errors = null)
        {
            var response = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, result, errors);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

    public class ValidationModelError
    {
        [JsonProperty("type")]
        public Uri Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        [JsonProperty("errors")]
        public Dictionary<string, string[]> Errors { get; set; }
    }
}