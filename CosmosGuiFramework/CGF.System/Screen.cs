using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public static class Screen
    {

        public static VBEScreen Vbe = new VBEScreen();

        public static int[] Buffer = new int[0];

        public static void Init()
        {
            Vbe.SetMode(VBEScreen.ScreenSize.Size800x600, VBEScreen.Bpp.Bpp24);
            Buffer = new int[Vbe.ScreenHeight * Vbe.ScreenWidth];
            for (int i = 0; i < Vbe.ScreenHeight * Vbe.ScreenWidth; i++)
            {
                Buffer[i] = 0;
            }
        }

        public static void Clear(int color)
        {
            for (int i = 0; i < Vbe.ScreenHeight * Vbe.ScreenWidth; i++)
            {
                Buffer[i] = color;
            }
            //Vbe.Clear((uint)color);
        }

        public static void SetPixel(int x, int y, int c)
        {
            Buffer[(y * Vbe.ScreenWidth) + x] = c;
        }

        public static void Redraw()
        {
            for (int x = 0; x < Vbe.ScreenWidth; x++)
            {
                for (int y = 0; y < Vbe.ScreenHeight; y++)
                {
                    var px = Buffer[(y * Vbe.ScreenWidth) + x];
                    if (Vbe.GetPixel((uint)x, (uint)y) != px)
                    {
                        Vbe.SetPixel((uint)x, (uint)y, (uint)px);
                    }
                }
            }
        }


    }
}
