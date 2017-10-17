using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace Basic.MEF
{
    public static class Composer
    {
        public static CompositionHost Compose()
        {
            var assemblies = new[] { typeof(Program).GetTypeInfo().Assembly };

            var configuration = new ContainerConfiguration().WithAssembly(typeof(Program).GetTypeInfo().Assembly);

            return configuration.CreateContainer();

        }
    }
}
