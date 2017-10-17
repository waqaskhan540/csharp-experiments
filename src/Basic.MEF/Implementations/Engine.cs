using Basic.MEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace Basic.MEF.Implementations
{
    [Export(typeof(IEngine))]
    
    public class Engine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Engine Started....");
        }
    }
}
