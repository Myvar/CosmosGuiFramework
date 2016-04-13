
using Cosmos.HAL;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public unsafe static class Screen
    {

        public static VBEScreen Vbe = new VBEScreen();

        public static byte[] BackBuffer = new byte[0];

        public static List<int> X_Changes = new List<int>();
        public static List<int> Y_Changes = new List<int>();
        public static List<int> C_Changes = new List<int>();

        public static void Init()
        {
            Vbe.SetMode(VBEScreen.ScreenSize.Size800x600, VBEScreen.Bpp.Bpp24);

            BackBuffer = new byte[(Vbe.ScreenHeight * Vbe.ScreenWidth) * 3];


            for (int i = 0; i < BackBuffer.Length; i++)
            {
                BackBuffer[0] = 0;
            }
        }

        public static void Clear(int color, bool Frame = false)
        {

            if (Frame)
            {

                Vbe.Clear((uint)color);
                for (uint x = 0; x < Vbe.ScreenWidth; x++)
                {
                    for (uint y = 0; y < Vbe.ScreenHeight; y++)
                    {
                        var c = color;

                        var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                        BackBuffer[where] = (byte)(c & 255);              // BLUE
                        BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                        BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED

                    }
                }
                Redraw();

            }
            else
            {
                for (int i = 0; i < X_Changes.Count; i++)
                {
                    var x = X_Changes[i];
                    var y = Y_Changes[i];
                    var c = color;

                    var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                    BackBuffer[where] = (byte)(c & 255);              // BLUE
                    BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                    BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED
                }
            }

            X_Changes.Clear();
            Y_Changes.Clear();
            C_Changes.Clear();

        }

        public static void SetPixel(int x, int y, int c)
        {
            X_Changes.Add(x);
            Y_Changes.Add(y);
            C_Changes.Add(c);

        }



        private static uint GetIntFromRBG(byte red, byte green, byte blue)
        {
            uint x;
            x = (blue);
            x += (uint)(green << 8);
            x += (uint)(red << 16);
            return x;
        }



        public static void Redraw()
        {


            for (int i = 0; i < X_Changes.Count; i++)
            {
                var x = X_Changes[i];
                var y = Y_Changes[i];
                var c = C_Changes[i];

                var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                BackBuffer[where] = (byte)(c & 255);              // BLUE
                BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED


            }

            Vbe.SetBuffer(BackBuffer);

        }

    }

    #region FPS29
    /*
     *public static VBEScreen Vbe = new VBEScreen();

        public static int[] Buffer = new int[0];
        public static byte[] BackBuffer = new byte[0];

        public static List<int> X_Changes = new List<int>();
        public static List<int> Y_Changes = new List<int>();

        public static void Init()
        {
            Vbe.SetMode(VBEScreen.ScreenSize.Size800x600, VBEScreen.Bpp.Bpp24);
            Buffer = new int[Vbe.ScreenHeight * Vbe.ScreenWidth];
            BackBuffer = new byte[(Vbe.ScreenHeight * Vbe.ScreenWidth) * 3];


            for (int i = 0; i < BackBuffer.Length; i++)
            {
                BackBuffer[0] = 0;
            }
        }

        public static void Clear(int color, bool Frame = false)
        {
            
            if (Frame)
            {
                for (int i = 0; i < Vbe.ScreenHeight * Vbe.ScreenWidth; i++)
                {
                    Buffer[i] = color;
                }
                Vbe.Clear((uint)color);
                for (uint x = 0; x < Vbe.ScreenWidth; x++)
                {
                    for (uint y = 0; y < Vbe.ScreenHeight; y++)
                    {
                        var c = Buffer[(y * Vbe.ScreenWidth) + x];
                        var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                        var get = GetIntFromRBG(BackBuffer[where + 2], BackBuffer[where + 1], BackBuffer[where]);
                        if (get != c)
                        {
                            where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                            BackBuffer[where] = (byte)(c & 255);              // BLUE
                            BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                            BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED
                        }
                    }
                }
                Redraw();

            }
            else
            {
                for (int i = 0; i < X_Changes.Count; i++)
                {
                    var x = X_Changes[i];
                    var y = Y_Changes[i];
                    var c = color;

                    var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                    BackBuffer[where] = (byte)(c & 255);              // BLUE
                    BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                    BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED
                }
            }

            X_Changes.Clear();
            Y_Changes.Clear();
    
        }

        public static void SetPixel(int x, int y, int c)
        {
            X_Changes.Add(x);
            Y_Changes.Add(y);

            Buffer[(y * Vbe.ScreenWidth) + x] = c;
        }



        private static uint GetIntFromRBG(byte red, byte green, byte blue)
        {
            uint x;
            x = (blue);
            x += (uint)(green << 8);
            x += (uint)(red << 16);
            return x;
        }



        public static void Redraw()
        {


            for (int i = 0; i < X_Changes.Count; i++)
            {
                var x = X_Changes[i];
                var y = Y_Changes[i];
                var c = Buffer[(y * Vbe.ScreenWidth) + x];
                    var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                    var get = GetIntFromRBG(BackBuffer[where + 2], BackBuffer[where + 1], BackBuffer[where]);
                    if (get != c)
                    {
                        where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                        BackBuffer[where] = (byte)(c & 255);              // BLUE
                        BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                        BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED
                    }
                
            }

            Vbe.SetBuffer(BackBuffer);

        }
     * */
    #endregion

    #region Fps10
    /*
    public static VBEScreen Vbe = new VBEScreen();

    public static int[] Buffer = new int[0];
    public static byte[] BackBuffer = new byte[0];

    public static void Init()
    {
        Vbe.SetMode(VBEScreen.ScreenSize.Size800x600, VBEScreen.Bpp.Bpp24);
        Buffer = new int[Vbe.ScreenHeight * Vbe.ScreenWidth];
        BackBuffer = new byte[(Vbe.ScreenHeight * Vbe.ScreenWidth) * 3]; 


        for (int i = 0; i < BackBuffer.Length; i++)
        {
            BackBuffer[0] = 0;
        }
    }

    public static void Clear(int color, bool Frame = false)
    {
        for (int i = 0; i < Vbe.ScreenHeight * Vbe.ScreenWidth; i++)
        {
            Buffer[i] = color;
        }
        if (Frame)
        {
            Redraw();
        }
    }

    public static void SetPixel(int x, int y, int c)
    {
        Buffer[(y * Vbe.ScreenWidth) + x] = c;
    }



    private static uint GetIntFromRBG(byte red, byte green, byte blue)
    {
        uint x;
        x = (blue);
        x += (uint)(green << 8);
        x += (uint)(red << 16);
        return x;
    }



    public static void Redraw()
    {


        for (uint x = 0; x < Vbe.ScreenWidth; x++)
        {
            for (uint y = 0; y < Vbe.ScreenHeight; y++)
            {
                var c = Buffer[(y * Vbe.ScreenWidth) + x];
                var where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                var get = GetIntFromRBG(BackBuffer[where + 2], BackBuffer[where + 1], BackBuffer[where]);
                if (get != c)
                {
                    where = x * ((uint)Vbe.ScreenBpp / 8) + y * (uint)(Vbe.ScreenWidth * ((uint)Vbe.ScreenBpp / 8));
                    BackBuffer[where] = (byte)(c & 255);              // BLUE
                    BackBuffer[where + 1] = (byte)((c >> 8) & 255);   // GREEN
                    BackBuffer[where + 2] = (byte)((c >> 16) & 255);  // RED
                }
            }
        }

        Vbe.SetBuffer(BackBuffer);

    }

}*/
    #endregion
}