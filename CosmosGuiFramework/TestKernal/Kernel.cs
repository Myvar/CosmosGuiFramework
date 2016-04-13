using CGF.System;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace TestKernal
{
    public class Kernel : Sys.Kernel
    {     
        protected override void BeforeRun()
        {
            Console.Clear();
            ScreenManager.Step();
        }

        protected override void Run()
        {
            ScreenManager.Init();
        }
    }
}
