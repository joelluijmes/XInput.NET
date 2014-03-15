using System.Runtime.InteropServices;

namespace XInput
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XINPUT_CAPABILITIES
    {
        public byte Type;
        public byte SubType;
        public ushort Flags;
        public XINPUT_GAMEPAD Gamepad;
        public XINPUT_VIBRATION Vibration;
    }
}