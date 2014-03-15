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

        private XINPUT_STATE _lastState;

        public event EventHandler<ButtonEventArgs> ButtonDown;
        public event EventHandler<ButtonEventArgs> ButtonUp;
        public event EventHandler<TriggerEventArgs> TriggerChanged;
        public event EventHandler<StickEventArgs> StickChanged;

        public event EventHandler DownA;
        public event EventHandler DownB;
        public event EventHandler DownY;
        public event EventHandler DownX;
        public event EventHandler DownRBack;
        public event EventHandler DownLBack;
        public event EventHandler DownBack;
        public event EventHandler DownStart;
        public event EventHandler DownRight;
        public event EventHandler DownLeft;
        public event EventHandler DownDDown;
        public event EventHandler DownDLeft;
        public event EventHandler DownDRight;
        public event EventHandler DownDUp;

        public event EventHandler UpA;
        public event EventHandler UpB;
        public event EventHandler UpY;
        public event EventHandler UpX;
        public event EventHandler UpRBack;
        public event EventHandler UpLBack;
        public event EventHandler UpBack;
        public event EventHandler UpStart;
        public event EventHandler UpRight;
        public event EventHandler UpLeft;
        public event EventHandler UpDDown;
        public event EventHandler UpDLeft;
        public event EventHandler UpDRight;
        public event EventHandler UpDUp;

        public XboxController(uint controller)
        {
            if (controller > Native.XUSER_MAX_COUNT - 1)
                throw new ArgumentException("Controller is not in valid range.", "controller");
            
            _controller = controller;
            _lastState = new XINPUT_STATE();

            ButtonDown += OnButtonDown;
            ButtonUp += OnButtonUp;
            TriggerChanged = delegate { };
            StickChanged = delegate { };

            _timer = new Timer(Timer);   
        }

        private void OnButtonUp(object sender, ButtonEventArgs buttonEventArgs)
        {
            if ((buttonEventArgs.Button & Button.A) != 0)
            {
                if (UpA != null)
                    UpA(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.B) != 0)
            {
                if (UpB != null)
                    UpB(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.Y) != 0)
            {
                if (UpY != null)
                    UpY(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.X) != 0)
            {
                if (UpX != null)
                    UpX(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.RIGHT_SHOULDER) != 0)
            {
                if (UpRBack != null)
                    UpRBack(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.LEFT_SHOULDER) != 0)
            {
                if (UpLBack != null)
                    UpLBack(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.BACK) != 0)
            {
                if (UpBack != null)
                    UpBack(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.START) != 0)
            {
                if (UpStart != null)
                    UpStart(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.RIGHT_THUMB) != 0)
            {
                if (UpRight != null)
                    UpRight(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.LEFT_THUMB) != 0)
            {
                if (UpLeft != null)
                    UpLeft(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_DOWN) != 0)
            {
                if (UpDDown != null)
                    UpDDown(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_RIGHT) != 0)
            {
                if (UpDRight != null)
                    UpDRight(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_LEFT) != 0)
            {
                if (UpDLeft != null)
                    UpDLeft(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_UP) != 0)
            {
                if (UpDUp != null)
                    UpDUp(this, EventArgs.Empty);
            }
        }

        private void OnButtonDown(object sender, ButtonEventArgs buttonEventArgs)
        {
            if ((buttonEventArgs.Button & Button.A) != 0)
            {
                if (DownA != null)
                    DownA(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.B) != 0)
            {
                if (DownB != null)
                    DownB(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.Y) != 0)
            {
                if (DownY != null)
                    DownY(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.X) != 0)
            {
                if (DownX != null)
                    DownX(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.RIGHT_SHOULDER) != 0)
            {
                if (DownRBack != null)
                    DownRBack(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.LEFT_SHOULDER) != 0)
            {
                if (DownLBack != null)
                    DownLBack(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.BACK) != 0)
            {
                if (DownBack != null)
                    DownBack(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.START) != 0)
            {
                if (DownStart != null)
                    DownStart(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.RIGHT_THUMB) != 0)
            {
                if (DownRight != null)
                    DownRight(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.LEFT_THUMB) != 0)
            {
                if (DownLeft != null)
                    DownLeft(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_DOWN) != 0)
            {
                if (DownDDown != null)
                    DownDDown(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_RIGHT) != 0)
            {
                if (DownDRight != null)
                    DownDRight(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_LEFT) != 0)
            {
                if (DownDLeft != null)
                    DownDLeft(this, EventArgs.Empty);
            }

            if ((buttonEventArgs.Button & Button.DPAD_UP) != 0)
            {
                if (DownDUp != null)
                    DownDUp(this, EventArgs.Empty);
            }
        }

        public void Start()
        {
            _timer.Change(0, 25);
        }

        private void Timer(object o)
        {
            var state = GetState();
            FilterState(ref state);

            if (state.dwPacketNumber == _lastState.dwPacketNumber)
                return; // no point to check for changes, or is it.. :P

            var upButtons = Enum.GetValues(typeof (Button)).Cast<Button>().Where(button => IsButtonUp(ref state, (uint) button)).Aggregate(new Button(), (current, button) => current | button);
            var downButtons = Enum.GetValues(typeof (Button)).Cast<Button>().Where(button => IsButtonDown(ref state, (uint) button)).Aggregate(new Button(), (current, button) => current | button);

            if (upButtons != 0)
                ButtonUp(this, new ButtonEventArgs(upButtons));

            if (downButtons != 0)
                ButtonDown(this, new ButtonEventArgs(downButtons));


            if (state.Gamepad.bLeftTrigger != _lastState.Gamepad.bLeftTrigger)  
                TriggerChanged(this, new TriggerEventArgs(state.Gamepad.bLeftTrigger, Side.Left));

            if (state.Gamepad.bRightTrigger != _lastState.Gamepad.bRightTrigger)
                TriggerChanged(this, new TriggerEventArgs(state.Gamepad.bRightTrigger, Side.Right));

            if (state.Gamepad.sThumbLX != _lastState.Gamepad.sThumbLX || state.Gamepad.sThumbLY != _lastState.Gamepad.sThumbLY)
                StickChanged(this, new StickEventArgs(state.Gamepad.sThumbLX, state.Gamepad.sThumbLY, Side.Left));

            if (state.Gamepad.sThumbRX != _lastState.Gamepad.sThumbRX || state.Gamepad.sThumbRY != _lastState.Gamepad.sThumbRY)
                StickChanged(this, new StickEventArgs(state.Gamepad.sThumbRX, state.Gamepad.sThumbRY, Side.Right));

            _lastState = state;
        }

        private bool IsButtonDown(ref XINPUT_STATE state, uint button)
        {
            return (((state.Gamepad.wButtons & button) != 0) && (_lastState.Gamepad.wButtons & button) == 0);
        }

        private bool IsButtonUp(ref XINPUT_STATE state, uint button)
        {
            return (((state.Gamepad.wButtons & button) == 0) && (_lastState.Gamepad.wButtons & button) != 0);
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
