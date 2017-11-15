using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hasty.ApiGenerator.Extensions
{
    public static class HttpRequestExtensions
    {
        public static async Task<string> GetRawBodyStringAsync(this HttpRequest httpRequest)
        {

            using (var reader = new StreamReader(httpRequest.Body, Encoding.UTF8))
                return await reader.ReadToEndAsync();
        }
    }
}
