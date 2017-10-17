using Basic.MEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace Basic.MEF.Implementations
{
    [Export(typeof(IBrakes))]
    public class Brakes : IBrakes
    {
        public void Stop()
        {
            Console.WriteLine("Stopping the car..breaks applied..");
        }
    }
}
