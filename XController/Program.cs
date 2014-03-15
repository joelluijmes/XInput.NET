using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XInput;
using Timer = System.Threading.Timer;

namespace XController
{
    static class Program
    {
        private static Timer _timer;
        private static Point _point;

        static void Main()
        {
            _timer = new Timer(Timer);
            _point = new Point();
            
            var controller = new XboxController(0);
            controller.DownA += (sender, args) => Mouse.LeftDown();
            controller.UpA += (sender, args) => Mouse.LeftUp();
            controller.DownB += (sender, args) => Mouse.RightDown();
            controller.UpB += (sender, args) => Mouse.RightUp();
            controller.StickChanged += ControllerOnStickChanged;
            controller.UpLeft += (sender, args) => Mouse.LeftClick();
            controller.DownRight += (sender, args) => Window.OpenSwitcher();
            controller.UpRight += (sender, args) => Window.CloseSwitcher();
            controller.UpRBack += (sender, args) => Window.SwitchNextWindow();
            controller.UpLBack += (sender, args) => Window.SwitchPreviousWindow();


            controller.Start();
            Process.GetCurrentProcess().WaitForExit();
        }

        private static void ControllerOnStickChanged(object sender, StickEventArgs stickEventArgs)
        {
            _point.X = stickEventArgs.X;
            _point.Y = stickEventArgs.Y;

            if (stickEventArgs.X != 0 || stickEventArgs.Y != 0)
                _timer.Change(25, 25);
            else
                _timer.Change(-1, -1);
        }

        private static void Timer(object obj)
        {
            Mouse.MoveByStickChange((short)_point.X, (short)_point.Y);
        }
    }
}
