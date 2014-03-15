using System.Runtime.InteropServices;
namespace XInput
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GUID
    {
        public uint Data1;
        public ushort Data2;
        public ushort Data3;
        public fixed byte Data4 [8];
    }
}
