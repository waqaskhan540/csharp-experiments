using Basic.MEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace MEF.MultipleAssemblyLoading
{
    public class Car
    {
        [Import]
        private IEngine _engine { get; set; }
        [Import]
        private ISteering _steering { get; set; }
        [Import]
        private IBrakes _brakes { get; set; }
        [Import]
        private ITransmission _transmission { get; set; }

      
        public void Drive()
        {
            _engine.Start();
            _transmission.ShiftUp();
            _steering.MoveLeft();
            _brakes.Stop();
        }
    }
}
