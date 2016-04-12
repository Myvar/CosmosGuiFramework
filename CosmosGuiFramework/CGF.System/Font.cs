using SharpFont;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public class Font
    {


        public Font(string File)
        {

        }

        public Font(byte[] File)
        {
            //test
            var x = new FontFace(new MemoryStream(File));
            
        }
    }
}
