using CGF.System.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System.Imaging.Decoders
{
    public class CIFDecoder : IImageDecoder
    {
        public int[] Map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string MagicNumber { get; set; }

        public CIFDecoder()
        {
            MagicNumber = "CIF"; //magicnumber
        }

        public void Load(byte[] raw)
        {
            RWStream str = new RWStream(raw);
            
            Width = str.ReadInt32();
            Height = str.ReadInt32();
            Map = new int[Width * Height];

            for (int i = 0; i < Width * Height; i++)
            {
                Map[i] = str.ReadInt32();//read hex value of pixle
            }
        }

        public string ReadMagicNumber(byte[] raw)
        {
            // RWStream str = new RWStream(raw);
            return "CIF";//str.ReadString();//magicnumber
        }
    }
}
