using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public class Graphics
    {
        public static void Line(int x, int y, int x2, int y2, Color color)
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

        public static void Rectangle(int x, int y, int w, int h, Color color)
        {
            Line(x, y, x, y + h, color);
            Line(x, y, x + w, y, color);
            Line(x, y + h, x + w, y + h, color);
            Line(x + w, y, x + w, y + h, color);
        }     

        public static void RectangleFill(int x, int y, int w, int h, Color color)
        {
            Line(x, y, x, y + h, color);
            Line(x, y, x + w, y, color);
            Line(x, y + h, x + w, y + h, color);
            Line(x + w, y, x + w, y + h, color);

            for (int i = 0; i < h; i++)
            {
                Line(x, y + i, x + w, y + i, color);
            }
        }
    }
}
