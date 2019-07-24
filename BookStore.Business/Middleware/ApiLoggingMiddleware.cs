using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Services.Abstracts;
using BookStore.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;

namespace BookStore.Business.Middleware
{
    public class ApiLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogService _apiLogService;

        public ApiLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogService apiLogService)
        {
            try
            {
                _apiLogService = apiLogService;
                var request = httpContext.Request;

                if (!IsApiRequest(request.Path.Value))
                {
                    await _next(httpContext);
                }
                else
                {
                    var stopWatch = Stopwatch.StartNew();
                    var requestTime = DateTime.UtcNow;
                    var requestBodyContent = await ReadRequestBody(request);
                    var originalBodyStream = httpContext.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        var response = httpContext.Response;
                        response.Body = responseBody;
                        await _next(httpContext);
                        stopWatch.Stop();

                        string responseBodyContent = null;
                        responseBodyContent = await ReadResponseBody(response);
                        await responseBody.CopyToAsync(originalBodyStream);

                        if (response.StatusCode != StatusCodes.Status200OK & response.StatusCode != StatusCodes.Status201Created)
                        {
                            await HandleExceptionAsync(httpContext, new Exception("RequestNotValid"));
                        }

                        await SafeLog(requestTime,
                            stopWatch.ElapsedMilliseconds,
                            response.StatusCode,
                            request.Method,
                            request.Path,
                            request.QueryString.ToString(),
                            requestBodyContent,
                            responseBodyContent);
                    }
                }
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonConvert.SerializeObject(new { error = ex });

            await SafeErrorLog(result);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        private async Task SafeLog(DateTime requestTime,
                            long responseMillis,
                            int statusCode,
                            string method,
                            string path,
                            string queryString,
                            string requestBody,
                            string responseBody)
        {

            if (requestBody.Length > 100)
            {
                requestBody = requestBody.Substring(0, 100);
            }

            if (responseBody.Length > 100)
            {
                responseBody = responseBody.Substring(0, 100);
            }

            if (queryString.Length > 100)
            {
                queryString = queryString.Substring(0, 100);
            }

            await _apiLogService.Log(new Log
            {
                RequestTime = requestTime,
                ResponseMillis = responseMillis,
                StatusCode = statusCode,
                Method = method,
                Path = path,
                QueryString = queryString,
                RequestBody = requestBody,
                ResponseBody = responseBody
            });
        }
        private async Task SafeErrorLog(string errorMessage)
        {

            if (errorMessage.Length > 100)
            {
                errorMessage = errorMessage.Substring(0, 100);
            }

            await _apiLogService.LogError(new ErrorLog
            {
                ErrorTime = DateTime.UtcNow,
                ErrorMessage = errorMessage
            });
        }
        private bool IsApiRequest(string value)
        {
            if (value.StartsWith("/index.html") || value == "/" || value.StartsWith("/favicon.ico") || value.StartsWith("/swagger"))
            {
                return false;
            }
            return true;
        }

    }
}