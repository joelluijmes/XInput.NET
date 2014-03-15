using System;

namespace XInput
{
    public class StickEventArgs : EventArgs
    {
        public short X { get; set; }
        public short Y { get; set; }
        public Side Side { get; set; }

        public StickEventArgs(short x, short y, Side side)
        {
            X = x;
            Y = y;
            Side = side;
        }
    }
}