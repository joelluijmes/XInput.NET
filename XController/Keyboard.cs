using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XController
{
    public unsafe static class Keyboard
    {
        public static void AltDown()
        {
            Native.keybd_event((byte) Keys.Menu, 0xB8, 0, null);
        }

        public static void TabDown()
        {
            Native.keybd_event((byte)Keys.Tab, 0x8F, 0, null);
        }

        public static void ShiftDown()
        {
            Native.keybd_event((byte)Keys.LShiftKey, 0xAA, 0, null);
        }

        public static void AltUp()
        {
            Native.keybd_event((byte)Keys.Menu, 0xB8, Native.KEYEVENTF_KEYUP, null);
        }

        public static void TabUp()
        {
            Native.keybd_event((byte)Keys.Tab, 0x8F, Native.KEYEVENTF_KEYUP, null);
        }

        public static void ShiftUp()
        {
            Native.keybd_event((byte)Keys.LShiftKey, 0xAA, Native.KEYEVENTF_KEYUP, null);
        }
    }
}
