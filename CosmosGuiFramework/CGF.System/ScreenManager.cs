using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGF.System
{
    public static class ScreenManager
    {

        public static List<IScreen> Screens = new List<IScreen>()
        {
            new Desktop()
        };
        public static int CurrentScreen = 0;

        public static void Init()
        {
            for (int i = 0; i < Screens.Count; i++)
            {
                Screens[i].Init();
            }
        }

        public static void ChangeScreen(int screen)
        {
            CurrentScreen = screen;
        }

        public static void Step()
        {            
            Screens[CurrentScreen].Handle();
        }
    }
}
