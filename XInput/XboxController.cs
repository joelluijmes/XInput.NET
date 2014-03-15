using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XInput
{
    public unsafe class XboxController
    {
        private readonly uint _controller;
        private readonly Timer _timer;

        private XINPUT_STATE lastState;

        public event EventHandler<ButtonEventArgs> ButtonDown;
        public event EventHandler<ButtonEventArgs> ButtonUp;
        public event EventHandler<TriggerEventArgs> TriggerChanged;
        public event EventHandler<StickEventArgs> StickChanged;

        public XboxController(uint controller)
        {
            if (controller > Native.XUSER_MAX_COUNT - 1)
                throw new ArgumentException("Controller is not in valid range.", "controller");

            _controller = controller;
            lastState = new XINPUT_STATE();

            ButtonDown = delegate { };
            ButtonUp = delegate { };
            TriggerChanged = delegate { };
            StickChanged = delegate { };

            _timer = new Timer(Timer, null, 0, 25);
        }

        private void Timer(object o)
        {
            var state = GetState();
            FilterState(ref state);

            if (state.dwPacketNumber == lastState.dwPacketNumber)
                return; // no point to check for changes, or is it.. :P

            var upButtons = Enum.GetValues(typeof (Button)).Cast<Button>().Where(button => IsButtonUp(ref state, (uint) button)).Aggregate(new Button(), (current, button) => current | button);
            var downButtons = Enum.GetValues(typeof (Button)).Cast<Button>().Where(button => IsButtonDown(ref state, (uint) button)).Aggregate(new Button(), (current, button) => current | button);

            if (upButtons != 0)
                ButtonUp(this, new ButtonEventArgs(upButtons));

            if (downButtons != 0)
                ButtonDown(this, new ButtonEventArgs(downButtons));


            if (state.Gamepad.bLeftTrigger != lastState.Gamepad.bLeftTrigger)  
                TriggerChanged(this, new TriggerEventArgs(state.Gamepad.bLeftTrigger, Side.Left));

            if (state.Gamepad.bRightTrigger != lastState.Gamepad.bRightTrigger)
                TriggerChanged(this, new TriggerEventArgs(state.Gamepad.bRightTrigger, Side.Right));

            if (state.Gamepad.sThumbLX != lastState.Gamepad.sThumbLX || state.Gamepad.sThumbLY != lastState.Gamepad.sThumbLY)
                StickChanged(this, new StickEventArgs(state.Gamepad.sThumbLX, state.Gamepad.sThumbLY, Side.Left));

            if (state.Gamepad.sThumbRX != lastState.Gamepad.sThumbRX || state.Gamepad.sThumbRY != lastState.Gamepad.sThumbRY)
                StickChanged(this, new StickEventArgs(state.Gamepad.sThumbRX, state.Gamepad.sThumbRY, Side.Right));

            lastState = state;
        }

        private bool IsButtonDown(ref XINPUT_STATE state, uint button)
        {
            return (((state.Gamepad.wButtons & button) != 0) && (lastState.Gamepad.wButtons & button) == 0);
        }

        private bool IsButtonUp(ref XINPUT_STATE state, uint button)
        {
            return (((state.Gamepad.wButtons & button) == 0) && (lastState.Gamepad.wButtons & button) != 0);
        }

        private void FilterState(ref XINPUT_STATE state)
        {
            if ((state.Gamepad.sThumbLX < Native.XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE &&
                 state.Gamepad.sThumbLX > -Native.XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE) &&
                (state.Gamepad.sThumbLY < Native.XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE &&
                 state.Gamepad.sThumbLY > -Native.XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE))
            {
                state.Gamepad.sThumbLX = 0;
                state.Gamepad.sThumbLY = 0;
            }

            if ((state.Gamepad.sThumbRX < Native.XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE &&
                 state.Gamepad.sThumbRX > -Native.XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE) &&
                (state.Gamepad.sThumbRY < Native.XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE &&
                 state.Gamepad.sThumbRY > -Native.XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE))
            {
                state.Gamepad.sThumbRX = 0;
                state.Gamepad.sThumbRY = 0;
            }

            if (state.Gamepad.bLeftTrigger < Native.XINPUT_GAMEPAD_TRIGGER_THRESHOLD)
                state.Gamepad.bLeftTrigger = 0;

            if (state.Gamepad.bRightTrigger < Native.XINPUT_GAMEPAD_TRIGGER_THRESHOLD)
                state.Gamepad.bRightTrigger = 0;
        }

        private XINPUT_STATE GetState()
        {
            XINPUT_STATE state;
            uint err;
            if ((err = Native.XInputGetState(_controller, &state)) != Native.ERROR_SUCCESS)
                throw new Win32Exception((int)err);

            return state;
        }
    }
}
