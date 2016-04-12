using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZorkMachine.Internals;

namespace ZorkMachine
{
    public class ZorkEngine
    {
        //public
        public ZorkStream Memmory;
        public byte[] Stack;
        public int ProgramCounter = 0;

        //private
        private int _MemmorySize = 128 * 1000;
        private int _StackSize = 100 * 1000;
        

        private StoryFile _sf;

        public ZorkEngine()
        {
            Memmory = new ZorkStream(new byte[_MemmorySize]);
            Stack = new byte[_StackSize];
        }

        public void Execute(byte[] zorkFile)
        {            
            _sf = StoryFile.Read(zorkFile);
            LoadStoryFile(_sf);
            Step();
        }

        public void Reset()
        {
            Memmory = new ZorkStream(new byte[_MemmorySize]);
            Stack = new byte[_StackSize];
        }

        private void LoadStoryFile(StoryFile f)
        {
            _MemmorySize = f.rawData.Length;
            Reset();
            Memmory = new ZorkStream(f.rawData);
            //TODO: load header data       
            ProgramCounter = f.Header.ProgramCounter;
        }

        private void Step()
        {
            Memmory._index = ProgramCounter - 1;

            Console.WriteLine("Opcode at PC:");
            Console.WriteLine(Memmory.ReadByte(ProgramCounter));

            var x = Opcode.ParseOpcode(Memmory);
           Console.WriteLine(x.BranchOffset_1);

            ProgramCounter++;
            //Step();
        }

    }
}
