using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkMachine.Internals
{
    public class StoryFile
    {
        #region Static    
        public static StoryFile Read(byte[] raw)
        {
            return new StoryFile(raw);
        }

        public static StoryFile Read(string file)
        {
            return Read(File.ReadAllBytes(file));
        }
        #endregion

        public byte[] rawData { get; set; }

        public Header Header { get; set; }
        public ZorkStream Stream { get; set; }

        public StoryFile(byte[] raw)
        {
            rawData = raw;
            Header = new Header(raw);
            Stream = new ZorkStream(raw);
        }

        public override string ToString()
        {
            return "Vertion: " + Header.Vertion
                + "\n" + "StatuslineType:" + BoolToString(Header.StatuslineType)
                + "\n" + "MultipleDisks:" + BoolToString(Header.MultipleDisks)
                + "\n" + "StatusLineNot:" + BoolToString(Header.StatusLineNot)
                + "\n" + "ScreenSplitting:" + BoolToString(Header.ScreenSplitting)
                + "\n" + "variablePitch:" + BoolToString(Header.variablePitch)
                + "\n" + "HighMemory:" + Header.HighMemory
                + "\n" + "ProgramCounter:" +  Header.ProgramCounter
                + "\n" + "DictionaryLoc:" + Header.DictionaryLoc
                + "\n" + "ObjectTableLoc:" + Header.ObjectTableLoc
                + "\n" + "GlobalVariableLoc:" + Header.GlobalVariableLoc
                + "\n" + "StaticMemmoryLoc:" + Header.StaticMemmoryLoc
                + "\n" + "TranscriptingIsOn:" + BoolToString(Header.TranscriptingIsOn)
                + "\n" + "ForcePitchFont:" + BoolToString(Header.ForcePitchFont)
                + "\n" + "AbbreviationTableLocation:" + Header.AbbreviationTableLocation
                + "\n" + "StandardRevisionNumber:" + Header.StandardRevisionNumber;
        }

        private static char ByteToHexChar(byte b)
        {            
            return b < 10 ? (char)(b + 48) : (char)(b + 55);
        }

        private string BoolToString(bool b)
        {
            return b ? "True" : "False";
        }
    }
}
