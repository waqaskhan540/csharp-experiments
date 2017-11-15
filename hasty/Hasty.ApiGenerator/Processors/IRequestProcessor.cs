using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hasty.ApiGenerator.Processors
{
    public interface IRequestProcessor
    {
        object Process();
    }
}
