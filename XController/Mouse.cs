using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace XController
{
    /// <summary>
    /// Wrapper over Native mouse_event
    /// </summary>
    public static unsafe class Mouse
    {
        private static int _fineTune = 7500;
        private static int _maxVelocity = 8;

        public static void LeftDown()
        {
            Native.mouse_event(Native.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, null);
            Console.WriteLine("[CLICK] Left Down");
        }

        public static void LeftUp()
        {
            Native.mouse_event(Native.MOUSEEVENTF_LEFTUP, 0, 0, 0, null);
            Console.WriteLine("[CLICK] Left Up");
        }

        public static void LeftClick()
        {
            LeftDown();
            LeftUp();
        }

        public static void RightDown()
        {
            Native.mouse_event(Native.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, null);
            Console.WriteLine("[CLICK] Right Down");
        }

        public static void RightUp()
        {
            Native.mouse_event(Native.MOUSEEVENTF_RIGHTUP, 0, 0, 0, null);
            Console.WriteLine("[CLICK] Right Up");
        }

        public static void RightClick()
        {
            RightDown();
            RightUp();
        }

        public static void MoveOffset(int offsetX, int offsetY)
        {
            if (offsetX == 0 && offsetY == 0)
                return;

            POINT p;
            if (Native.GetCursorPos(&p) == false)
                throw new Win32Exception();

            var x = (int)p.x + offsetX;
            var y = (int)p.y + offsetY;
            if (Native.SetCursorPos(x, y) == false)
                throw new Win32Exception();

            Console.WriteLine("[MOVE] X: {0} Y: {1}", x, y);
        }

        public static void MoveByStickChange(short x, short y)
        {
            x = (short)(x*(x > 0 ? x/_fineTune : x/-_fineTune)*_maxVelocity/32767);
            y = (short) (y*(y > 0 ? y/-_fineTune : y/_fineTune)*_maxVelocity/32767);

            MoveOffset(x, y);
        }
    }
}
