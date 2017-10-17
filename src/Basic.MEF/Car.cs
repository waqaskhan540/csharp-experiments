using Basic.MEF.Implementations;
using Basic.MEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace Basic.MEF
{
    class Car
    {
        [Import]
        public IEngine _engine { get; set; }
        [Import]
        public IBrakes _brakes { get; set; }
        [Import]
        public ISteering _steering { get; set; }
        [Import]
        public ITransmission _transmission { get; set; }

        public Car()
        {
            //var container = Composer.Compose();
            //_engine = container.GetExport<IEngine>();
            //_brakes = container.GetExport<IBrakes>();
            //_steering = container.GetExport<ISteering>();
            //_transmission = container.GetExport<ITransmission>();

        }

        public void Drive()
        {
            _engine.Start();
            _transmission.ShiftUp();
            _steering.MoveLeft();
            _brakes.Stop();
        }
    }
}
