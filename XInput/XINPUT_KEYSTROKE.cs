using System.Runtime.InteropServices;

namespace XInput
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XINPUT_KEYSTROKE
    {
        public ushort VirtualKey;
        public ushort Unicode; //WCHAR -> Wide Character => 2 bytes (I Think???)
        public ushort Flags;
        public byte UserIndex;
        public byte HidCode;
    }
}