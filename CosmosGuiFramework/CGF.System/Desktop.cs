using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public class Desktop
    {
        public Color BackGroundColor = new Color(0xC0FFEE);//hex 

        public void Init()
        {
            //init screen and doublebuffer
            Screen.Init();
        }

        public void ReDraw()
        {
            Screen.Clear(BackGroundColor);

            Graphics.Line(10, 10, 50, 70, Colors.Black);

            //always redraw last
            Screen.Redraw();
        }

    }
}
