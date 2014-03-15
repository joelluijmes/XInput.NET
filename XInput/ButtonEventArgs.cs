using System;

namespace XInput
{
    public class ButtonEventArgs : EventArgs
    {
        public Button Button { get; set; }

        public ButtonEventArgs(Button button)
        {
            Button = button;
        }
    }
}