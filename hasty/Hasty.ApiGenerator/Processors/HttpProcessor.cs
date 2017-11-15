using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hasty.ApiGenerator.Processors
{
    public class HttpProcessor<T> where T:class
    {
        private readonly string _reqeustMethod;
        private readonly string _entity;
        private readonly Dictionary<string, IRequestProcessor> _processors;
        private readonly HttpRequest _httpRequest;
        public HttpProcessor(string requestMethod,string entity,HttpRequest httpRequest)
        {
            _reqeustMethod = requestMethod ?? throw new ArgumentNullException(nameof(requestMethod));
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            _httpRequest = httpRequest;

            _processors = new Dictionary<string, IRequestProcessor>
            {
               {    "GET",  new HttpGetProcessor<T>(entity)  },
               {    "POST", new HttpPostProcessor(entity,_httpRequest) }
            };
        }

        public object Process()
        {
            return _processors[_reqeustMethod].Process();
        }
    }
}
