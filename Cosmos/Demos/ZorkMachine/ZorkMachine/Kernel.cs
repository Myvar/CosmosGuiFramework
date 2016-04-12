using System;
using System.Collections.Generic;
using System.Text;
using ZorkMachine.Internals;
using Sys = Cosmos.System;

namespace ZorkMachine
{
    public class Kernel : Sys.Kernel
    {
        public ZorkEngine ze = new ZorkEngine();

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("ZorkMachine");

            Console.WriteLine("Test File: Minizork");
            Console.WriteLine("File Info:");

            StoryFile f = new StoryFile(minizork_z3.raw);
            Console.WriteLine(f.ToString());


            ZorkEngine ze = new ZorkEngine();
            ze.Execute(minizork_z3.raw);        
        }

        protected override void Run()
        {
            
        }
    }
}
