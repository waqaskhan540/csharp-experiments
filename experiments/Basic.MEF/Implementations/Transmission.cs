using Basic.MEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace Basic.MEF.Implementations
{
    [Export(typeof(ITransmission))]
    public class Transmission : ITransmission
    {
        private int Gear = 0;
        public void ShiftDown()
        {
            Gear--;
            Console.WriteLine($"Current Gear : {Gear}");
        }

        public void ShiftUp()
        {
            Gear++;
            Console.WriteLine($"Current Gear : {Gear}");
        }
    }
}
