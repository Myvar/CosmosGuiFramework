using CGF.System.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public class Graphics
    {
        public static void DrawLine(int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = w;
            int shortest = h;
            if (!(longest > shortest))
            {
                longest = h;
                shortest = w;
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                Screen.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        public static void DrawRectangle(int x, int y, int w, int h, Color color)
        {
            DrawLine(x, y, x, y + h, color);
            DrawLine(x, y, x + w, y, color);
            DrawLine(x, y + h, x + w, y + h, color);
            DrawLine(x + w, y, x + w, y + h, color);
        }
        

        public static void FillRectangle(int x, int y, int w, int h, Color color)
        {
            DrawLine(x, y, x, y + h, color);
            DrawLine(x, y, x + w, y, color);
            DrawLine(x, y + h, x + w, y + h, color);
            DrawLine(x + w, y, x + w, y + h, color);

            for (int i = 0; i < h; i++)
            {
                DrawLine(x, y + i, x + w, y + i, color);
            }
        }

        public static int DrawChar(char c, int x, int y, Color color, Font f)
        {
            var index = 0;
            for (int i = 0; i < f.Char.Count; i++)
            {
                if(c == f.Char[i])
                {
                    index = i;
                    break;
                }
            }

            var width = f.Width[index];

            int z = 0;
            for (int p = y; p < y + f.Height[index]; p++)
            {
                for (int i = x; i < x + width; i++)
                {
                    if (f.Data[index][z] == 1)
                    {
                        Screen.SetPixel(i, p, color);
                    }

                    z++;
                }
            }

            return width;
        }

        public static void DrawString(string c, int x, int y, Color color, Font f)
        {
            int totalwidth = 0;
            for (int i = 0; i < c.Length; i++)
            {
                
                var ch = c[i];
                if (ch == ' ')
                {
                    totalwidth += f.Width[0];
                }
                else if (ch == '\t')
                {
                    totalwidth += (f.Width[0] * 4);
                }
                else
                {
                    totalwidth += DrawChar(ch, x + totalwidth, y, color, f);
                }

            }
        }

        public static void DrawImage(Image img, int x, int y, Color TransparencyKey = null)
        {
            int z = 0;
            for (int p = y; p < y + img.Height; p++)
            {
                for (int i = x; i < x + img.Width; i++)
                {
                    if (TransparencyKey != null)
                    {
                        if(img.Map[z] != TransparencyKey.ToHex())
                        {
                            Screen.SetPixel(i, p, img.Map[z]);
                        }
                    }
                    else
                    {
                        Screen.SetPixel(i, p, img.Map[z]);
                    }

                    z++;
                }
            }
        }
    }
}
