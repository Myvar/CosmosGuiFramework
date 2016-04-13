using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public static class Colors
    {
        public static Color Red { get; set; } = new Color(255, 0, 0);
        public static Color Black { get; set; } = new Color();
        public static Color White { get; set; } = new Color(255,255,255);

        public static Color FromName(string name)
        {
            switch(name.ToLower())
            {
                case "red":
                    return Red;
                case "black":
                    return Black;
            }

            return new Color();
        }
    }
}