using System;
using Hasty.ApiGenerator.Helpers;

namespace Hasty.ApiGenerator.Processors
{
    public class HttpGetProcessor<T> : IRequestProcessor where T:class
    {
        private readonly string _entity;
        public HttpGetProcessor(string entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
       
        public object Process()
        {
            return RoslynHelper.GetEntities<T>(_entity);
        }
    }
}
