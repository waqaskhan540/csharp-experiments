using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace MEF.MultipleAssemblyLoading
{
   public static class Composer
    {
        public static CompositionHost Compose()
        {

            var executeableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executeableLocation), "Plugins");
            var assemblies = Directory
                    .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                    .ToList();

            var container = new ContainerConfiguration().WithAssemblies(assemblies);
            return container.CreateContainer();
        }
    }
}
