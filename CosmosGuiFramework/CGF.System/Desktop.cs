using CGF.System.Imaging;
using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public class Desktop : IScreen
    {
        public Color BackGroundColor = new Color(0xC0FFEE);//hex 

        public void Init()
        {
            //init screen and doublebuffer
            Screen.Init();
            //always init mouse agfter screen
            Cursor.Init();
            Cursor.Enabled = true;
            Screen.Clear(BackGroundColor, true);
            deltaT = RTC.Second;
            Cursor.Image = Image.Load(Internals.Files.Cursors.Normal);
        }

        int c = 0;
        int Frames = 0;
        int FPS = 0;
        int deltaT = 0;
        public void ReDraw()
        {
            //alwas clear first
            Screen.Clear(BackGroundColor);

           


            if (deltaT != RTC.Second)
            {
                FPS = Frames;
                Frames = 0;
                deltaT = RTC.Second;
                Console.Clear();
                
               
            }

            Graphics.DrawString("FPS: " + FPS, 10, 10, Colors.Black, CGF.System.Internals.Files.Fonts.Consolas14_cff);

            Graphics.DrawLine(50, 50, 100, 70 + 50, Colors.Black);

            Graphics.DrawRectangle(50, 50, 50, 50, Colors.Black);


            //mouse must alwasy be ontop
            Cursor.Render();

            //always redraw last
            Screen.Redraw();

            Frames++;
        }

        public void Handle()
        {
            ReDraw();
        }
    }
}
