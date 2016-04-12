using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkMachine.Internals
{
    public class Header
    {

        //public
        public short Vertion { get; set; }
        //flags 1
        public bool StatuslineType { get; set; }
        public bool MultipleDisks { get; set; }
        public bool StatusLineNot { get; set; }
        public bool ScreenSplitting { get; set; }
        public bool variablePitch { get; set; }

        public short HighMemory { get; set; }
        public short ProgramCounter { get; set; }
        public short DictionaryLoc { get; set; }
        public short ObjectTableLoc { get; set; }
        public short GlobalVariableLoc { get; set; }
        public short StaticMemmoryLoc { get; set; }
        //flags 2
        public bool TranscriptingIsOn { get; set; }
        public bool ForcePitchFont { get; set; }

        public short AbbreviationTableLocation { get; set; }
        public short StandardRevisionNumber { get; set; }

        //private
        private byte[] _raw;

        public Header(byte[] raw)
        {
            _raw = raw;
            Parse();
        }

        private void Parse()
        {
            ZorkStream zs = new ZorkStream(_raw);
            Vertion = zs.ReadByte(0x0);
            //flags 1
            var f1 = zs.ReadByte(0x1);
            StatuslineType = GetBit(f1, 1);
            MultipleDisks = GetBit(f1, 2);
            StatusLineNot = GetBit(f1, 4);
            ScreenSplitting = GetBit(f1, 5);
            variablePitch = GetBit(f1, 6);
            zs.ReadByte();

            HighMemory = zs.ReadShort(0x4);
            ProgramCounter = zs.ReadShort(0x6);
            
            DictionaryLoc = zs.ReadShort(0x8);
            ObjectTableLoc = zs.ReadShort(0xa);
            GlobalVariableLoc = zs.ReadShort(0xc);
            StaticMemmoryLoc = zs.ReadShort(0xe);
            //flags 2
            var f2 = zs.ReadByte(0x10);
            TranscriptingIsOn = GetBit(f2, 0);
            ForcePitchFont = GetBit(f2, 1);

            AbbreviationTableLocation = zs.ReadShort(0x18);
            StandardRevisionNumber = zs.ReadShort(0x32);

        }

        private bool GetBit(byte b , int bitNumber)
        {
           return (b & (1 << bitNumber - 1)) != 0;
        }
    }
}
