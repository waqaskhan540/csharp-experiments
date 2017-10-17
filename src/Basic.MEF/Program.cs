
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Basic.MEF
{
    class Program
    {
  
        static void Main(string[] args)
        {


            Car car = new Car();

            var container = Composer.Compose();
            container.SatisfyImports(car);

            car.Drive();
            Console.ReadKey();
        }

      
    }





  
}
