using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInput
{
    public partial class Native
    {
        public const uint ERROR_SUCCESS = 0;
        public const uint ERROR_EMPTY = 0x10D2;

        public const uint XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE = 7849;
        public const uint XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE = 8689;
        public const uint XINPUT_GAMEPAD_TRIGGER_THRESHOLD = 30;

        public const uint XINPUT_GAMEPAD_DPAD_UP = 0x0001;
        public const uint XINPUT_GAMEPAD_DPAD_DOWN = 0x0002;
        public const uint XINPUT_GAMEPAD_DPAD_LEFT = 0x0004;
        public const uint XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008;
        public const uint XINPUT_GAMEPAD_START = 0x0010;
        public const uint XINPUT_GAMEPAD_BACK = 0x0020;
        public const uint XINPUT_GAMEPAD_LEFT_THUMB = 0x0040;
        public const uint XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080;
        public const uint XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100;
        public const uint XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200;
        public const uint XINPUT_GAMEPAD_A = 0x1000;
        public const uint XINPUT_GAMEPAD_B = 0x2000;
        public const uint XINPUT_GAMEPAD_X = 0x4000;
        public const uint XINPUT_GAMEPAD_Y = 0x8000;

        public const uint XINPUT_FLAG_GAMEPAD = 0x00000001;

        public const uint BATTERY_DEVTYPE_GAMEPAD = 0x00;
        public const uint BATTERY_DEVTYPE_HEADSET = 0x01;

        public const uint BATTERY_TYPE_DISCONNECTED = 0x00;
        public const uint BATTERY_TYPE_WIRED = 0x01;
        public const uint BATTERY_TYPE_ALKALINE = 0x02;
        public const uint BATTERY_TYPE_NIMH = 0x03;
        public const uint BATTERY_TYPE_UNKNOWN = 0xFF;

        public const uint BATTERY_LEVEL_EMPTY = 0x00;
        public const uint BATTERY_LEVEL_LOW = 0x01;
        public const uint BATTERY_LEVEL_MEDIUM = 0x02;
        public const uint BATTERY_LEVEL_FULL = 0x03;

        public const uint XUSER_MAX_COUNT = 4;

        public const uint XUSER_INDEX_ANY = 0x000000FF;

        public const uint VK_PAD_A = 0x5800;
        public const uint VK_PAD_B = 0x5801;
        public const uint VK_PAD_X = 0x5802;
        public const uint VK_PAD_Y = 0x5803;
        public const uint VK_PAD_RSHOULDER = 0x5804;
        public const uint VK_PAD_LSHOULDER = 0x5805;
        public const uint VK_PAD_LTRIGGER = 0x5806;
        public const uint VK_PAD_RTRIGGER = 0x5807;

        public const uint VK_PAD_DPAD_UP = 0x5810;
        public const uint VK_PAD_DPAD_DOWN = 0x5811;
        public const uint VK_PAD_DPAD_LEFT = 0x5812;
        public const uint VK_PAD_DPAD_RIGHT = 0x5813;
        public const uint VK_PAD_START = 0x5814;
        public const uint VK_PAD_BACK = 0x5815;
        public const uint VK_PAD_LTHUMB_PRESS = 0x5816;
        public const uint VK_PAD_RTHUMB_PRESS = 0x5817;

        public const uint VK_PAD_LTHUMB_UP = 0x5820;
        public const uint VK_PAD_LTHUMB_DOWN = 0x5821;
        public const uint VK_PAD_LTHUMB_RIGHT = 0x5822;
        public const uint VK_PAD_LTHUMB_LEFT = 0x5823;
        public const uint VK_PAD_LTHUMB_UPLEFT = 0x5824;
        public const uint VK_PAD_LTHUMB_UPRIGHT = 0x5825;
        public const uint VK_PAD_LTHUMB_DOWNRIGHT = 0x5826;
        public const uint VK_PAD_LTHUMB_DOWNLEFT = 0x5827;

        public const uint VK_PAD_RTHUMB_UP = 0x5830;
        public const uint VK_PAD_RTHUMB_DOWN = 0x5831;
        public const uint VK_PAD_RTHUMB_RIGHT = 0x5832;
        public const uint VK_PAD_RTHUMB_LEFT = 0x5833;
        public const uint VK_PAD_RTHUMB_UPLEFT = 0x5834;
        public const uint VK_PAD_RTHUMB_UPRIGHT = 0x5835;
        public const uint VK_PAD_RTHUMB_DOWNRIGHT = 0x5836;
        public const uint VK_PAD_RTHUMB_DOWNLEFT = 0x5837;

        public const uint XINPUT_KEYSTROKE_KEYDOWN = 0x0001;
        public const uint XINPUT_KEYSTROKE_KEYUP = 0x0002;
        public const uint XINPUT_KEYSTROKE_REPEAT = 0x0004;
    }
}
