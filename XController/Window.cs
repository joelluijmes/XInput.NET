using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XController
{
    public static class Window
    {
        private static bool _isOpen = false;
        public static void OpenSwitcher()
        {
            Keyboard.AltDown();
            Keyboard.TabDown();
            Keyboard.TabUp();

            _isOpen = true;
        }

        public static void CloseSwitcher()
        {
            Keyboard.AltUp();
            _isOpen = false;
        }

        public static void SwitchPreviousWindow()
        {
            if (!_isOpen) return; 
            Keyboard.ShiftDown();
            Keyboard.TabDown();
            Keyboard.TabUp();
            Keyboard.ShiftUp();
        }

        public static void SwitchNextWindow()
        {
            if (!_isOpen) return; 
            Keyboard.TabDown();
            Keyboard.TabUp();
        }
    }
}
