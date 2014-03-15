using System;

namespace XInput
{
    public class TriggerEventArgs : EventArgs
    {
        public byte Value { get; set; }
        public Side Side { get; set; }

        public TriggerEventArgs(byte value, Side side)
        {
            Value = value;
            Side = side;
        }
    }
}