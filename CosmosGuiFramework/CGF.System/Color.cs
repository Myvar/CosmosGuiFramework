using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public class Color
    {
        //public byte R { get; set; }
        // public byte G { get; set; }
        // public byte B { get; set; }

        private byte _R;

        public byte R
        {
            get { return _R; }
            set {
                _R = value;
                _Hex = ((R << 16) | (G << 8) | B);
            }
        }

        private byte _G;

        public byte G
        {
            get { return _G; }
            set {
                _G = value;
                _Hex = ((R << 16) | (G << 8) | B);
            }
        }

        private byte _B;

        public byte B
        {
            get { return _B; }
            set {
                _B = value;
                _Hex = ((R << 16) | (G << 8) | B);
            }
        }


        private int _Hex { get; set; }

        public Color(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public Color(int hex)
        {
            R = ((byte)(hex >> 16)); 
            G = ((byte)(hex >> 8)); 
            B = ((byte)(hex >> 0)); 
        }

        public Color()
        {

        }

        public int ToHex() => _Hex;

        public static implicit operator int(Color c)
        {
            return c.ToHex();
        }
    }
}