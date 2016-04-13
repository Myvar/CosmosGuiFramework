using CGF.System.Imaging.Decoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System.Imaging
{
    public class Image
    {
        public int[] Map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static List<IImageDecoder> Decoders = new List<IImageDecoder>()
        {
            new CIFDecoder()
        };

        public static Image Load(byte[] raw)
        {
            var img = new Image();

            for (int i = 0; i < Decoders.Count; i++)
            {
                var dec = Decoders[i];               

                if(dec.ReadMagicNumber(raw) == dec.MagicNumber)
                {
                    dec.Load(raw);
                    img.Height = dec.Height;
                    img.Width = dec.Width;
                    img.Map = dec.Map;
                }
            }

            return img;
        }
    }
}
