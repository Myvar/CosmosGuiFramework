using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkMachine;
using ZorkMachine.Internals;

namespace ZorkConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("ZorkMachine");

            Console.WriteLine("Test File: Minizork");
            Console.WriteLine("File Info:");

            StoryFile f = new StoryFile(File.ReadAllBytes("minizork.z3"));
            Console.WriteLine(f.ToString());

            ZorkEngine ze = new ZorkEngine();
            ze.Execute(minizork_z3.raw);

            Console.ReadLine();
        }
    }
}
