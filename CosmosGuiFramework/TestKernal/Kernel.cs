using CGF.System;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace TestKernal
{
    public class Kernel : Sys.Kernel
    {
        private Desktop d = new Desktop();



        protected override void BeforeRun()
        {
            Console.Clear();
            var f = new Font(TestFiles.PlayRegular_ttf);

            //d.Init();
        }

        protected override void Run()
        {
           // d.ReDraw();
        }
    }
}
