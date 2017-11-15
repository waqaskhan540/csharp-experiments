using Hasty.ApiGenerator.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hasty.ApiGenerator.Processors
{
    public class HttpPostProcessor : IRequestProcessor
    {
        private readonly string _entity;
        private readonly Dictionary<string, string> _paramDictionary;
        private readonly HttpRequest _httpRequest;
        public HttpPostProcessor(string entity,HttpRequest httpRequest)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            _httpRequest = httpRequest;
        }
        public object Process()
        {
            if (null == _httpRequest)
                throw new ArgumentNullException(nameof(_httpRequest));

            string requestBody = _httpRequest.GetRawBodyStringAsync().Result;
            var model = requestBody.AsJsonString();
            





        }
    }
}
