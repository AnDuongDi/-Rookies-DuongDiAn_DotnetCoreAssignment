using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace DotnetCore
{
    public class LogInMiddleware
    {
        private readonly RequestDelegate _next;
        public LogInMiddleware(RequestDelegate next)
        {
             this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            string log = "Schema: " + request.Scheme
                        + "Host: " + request.Host
                        + "Path: " + request.Path
                        + "Query string: " + request.QueryString
                        + "Request body: " + request.Body;

            using(var buffer = new MemoryStream()){
                //var stream = response.Body;
                //response.Body = buffer;
                await this._next(context);
                Debug.Write(log);
                using(FileStream file = new FileStream("file.txt", FileMode.Create, System.IO.FileAccess.Write))
                    await buffer.CopyToAsync(file);
            } 
        }
    }
}