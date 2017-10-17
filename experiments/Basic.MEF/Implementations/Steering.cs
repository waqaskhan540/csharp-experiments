using Basic.MEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace Basic.MEF.Implementations
{
    [Export(typeof(ISteering))]
    public class Steering : ISteering
    {
       
        public void MoveLeft()
        {
          
            Console.WriteLine("Moving left...");
        }

        public void MoveRight()
        {
            Console.WriteLine("Moving right...");
        }
    }
}
