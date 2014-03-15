using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XController
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public uint x;
        public uint y;
    }

    public unsafe static class Native
    {
        public const uint   MOUSEEVENTF_LEFTDOWN      = 0x0002,
                            MOUSEEVENTF_LEFTUP        = 0x0004,
                            MOUSEEVENTF_MIDDLEDOWN    = 0x0020,
                            MOUSEEVENTF_MIDDLEUP      = 0x0040,
                            MOUSEEVENTF_MOVE          = 0x0001,
                            MOUSEEVENTF_RIGHTDOWN     = 0x0008,
                            MOUSEEVENTF_RIGHTUP       = 0x0010,
                            MOUSEEVENTF_XDOWN         = 0x0080,
                            MOUSEEVENTF_XUP           = 0x0100,
                            MOUSEEVENTF_WHEEL         = 0x0800,
                            MOUSEEVENTF_HWHEEL        = 0x1000,
                            MOUSEEVENTF_ABSOLUTE      = 0x8000;

        public const uint   GW_HWNDFIRST    = 0,
                            GW_HWNDLAST     = 1,
                            GW_HWNDNEXT     = 2,
                            GW_HWNDPREV     = 3,
                            GW_OWNER        = 4,
                            GW_CHILD        = 5,
                            GW_ENABLEDPOPUP = 6;

        public const uint   KEYEVENTF_EXTENDEDKEY   = 0x0001,
                            KEYEVENTF_KEYUP         = 0x0002;

        public const byte   VK_MENU     = 0x12,
                            VK_TAB      = 0x09;

        /// <summary>
        /// The mouse_event function synthesizes mouse motion and button clicks.
        /// </summary>
        /// <param name="dwFlag">Controls various aspects of mouse motion and button clicking. </param>
        /// <param name="dx">The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated, depending on the setting of MOUSEEVENTF_ABSOLUTE. Absolute data is specified as the mouse's actual x-coordinate; relative data is specified as the number of mickeys moved. A mickey is the amount that a mouse has to move for it to report that it has moved.</param>
        /// <param name="dy">The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated, depending on the setting of MOUSEEVENTF_ABSOLUTE. Absolute data is specified as the mouse's actual y-coordinate; relative data is specified as the number of mickeys moved.</param>
        /// <param name="dwData">If dwFlags contains MOUSEEVENTF_WHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was tilted to the right; a negative value indicates that the wheel was tilted to the left.
        /// If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then dwData specifies which X buttons were pressed or released. This value may be any combination of the following flags.
        /// If dwFlags is not MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then dwData should be zero.</param>
        /// <param name="dwExtraInfo">An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.</param>
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlag, uint dx, uint dy, uint dwData, uint* dwExtraInfo);

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <param name="lpPoint">A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(POINT* lpPoint);

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="x">The new x-coordinate of the cursor, in screen coordinates.</param>
        /// <param name="y">The new y-coordinate of the cursor, in screen coordinates.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</param>
        /// <param name="uCmd">The relationship between the specified window and the window whose handle is to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the specified window, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern void* GetWindow(void* hWnd, uint uCmd);

        /// <summary>
        /// Retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose parent window handle is to be retrieved.</param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window with the WS_POPUP style, the return value is a handle to the owner window.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// This function typically fails for one of the following reasons:
        /// * The window is a top-level window that is unowned or does not have the WS_POPUP style.
        /// * The owner window has WS_POPUP style.</returns>
        [DllImport("user32.dll")]
        public static extern void* GetParent(void* hWnd);

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="hWnd">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns>If the window was brought to the foreground, the return value is nonzero.
        /// If the window was not brought to the foreground, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(void* hWnd);

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns>The return value is a handle to the foreground window. The foreground window can be NULL in certain circumstances, such as when a window is losing activation.</returns>
        [DllImport("user32.dll")]
        public static extern void* GetForegroundWindow();

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero.
        /// Because the return value specifies whether the window has the WS_VISIBLE style, it may be nonzero even if the window is totally obscured by other windows.</returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(void* hWnd);

        /// <summary>
        /// Determines which pop-up window owned by the specified window was most recently active.
        /// </summary>
        /// <param name="hWnd">A handle to the owner window.</param>
        /// <returns>The return value identifies the most recently active pop-up window. The return value is the same as the hWnd parameter, if any of the following conditions are met:
        /// * The window identified by hWnd was most recently active.
        /// * The window identified by hWnd does not own any pop-up windows.
        /// * The window identifies by hWnd is not a top-level window, or it is owned by another window.</returns>
        [DllImport("user32.dll")]
        public static extern void* GetLastActivePopup(void* hWnd);

        /// <summary>
        /// Synthesizes a keystroke. The system can use such a synthesized keystroke to generate a WM_KEYUP or WM_KEYDOWN message. The keyboard driver's interrupt handler calls the keybd_event function.
        /// </summary>
        /// <param name="bVk">A virtual-key code. The code must be a value in the range 1 to 254. For a complete list, see Virtual Key Codes.</param>
        /// <param name="bScan">A hardware scan code for the key.</param>
        /// <param name="dwFlags">Controls various aspects of function operation. </param>
        /// <param name="dwExtraInfo">An additional value associated with the key stroke.</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint* dwExtraInfo);
    }
}
