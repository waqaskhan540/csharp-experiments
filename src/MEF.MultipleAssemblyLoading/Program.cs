using System;
using System.Composition;

namespace MEF.MultipleAssemblyLoading
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
