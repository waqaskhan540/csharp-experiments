using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;
using Hasty.ApiGenerator.Processors;
using Hasty.ApiGenerator.Extensions;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace Hasty.ApiGenerator
{
    public class Middleware<T> where T:class
    {
        private readonly RequestDelegate _next;
      
        public Middleware(RequestDelegate next)
        {           
            _next = next;
        }

        
        public async Task Invoke(HttpContext context)
        {

            var path = context.Request.Path.Value;
            var entity = path.GetEntityName();
            var method = context.Request.Method;
            var request = context.Request;

            var type = typeof(T).GetTypeInfo().GetProperty(entity);          
            if(null == type)
            {
                await context.Response.WriteAsync("No API configured for the given Uri");
                return;
            }

           
            request.EnableRewind();

            var processor = new HttpProcessor<T>(method, entity,request);
            var result = processor.Process();

            request.Body.Position = 0;
            if (result != null)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                return;
            }
            

            await _next(context);
        }
    }

   
}
