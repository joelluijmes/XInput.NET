using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XInput
{
    public static unsafe partial class Native
    {
        private const string dllPath = "xinput1_3.dll";

        /// <summary>
        /// Sets the reporting state of XInput.
        /// </summary>
        /// <param name="enable">If enable is FALSE, XInput will only send neutral data in response to XInputGetState (all buttons up, axes centered, and triggers at 0). XInputSetState calls will be registered but not sent to the device. Sending any value other than FALSE will restore reading and writing functionality to normal.</param>
        [DllImport(dllPath)]
        public static extern void XInputEnable(bool enable);


        /// <summary>
        /// Retrieves the sound rendering and sound capture audio device IDs that are associated with the headset connected to the specified controller.
        /// </summary>
        /// <param name="dwUserIndex">Index of the gamer associated with the device.</param>
        /// <param name="pRenderDeviceId">Windows Core Audio device ID string for render (speakers).</param>
        /// <param name="pRenderCount">Size, in wide-chars, of the render device ID string buffer.</param>
        /// <param name="pCaptureDeviceId">Windows Core Audio device ID string for capture (microphone).</param>
        /// <param name="pCaptureCount">Size, in wide-chars, of capture device ID string buffer.</param>
        /// <returns>If the function successfully retrieves the device IDs for render and capture, the return code is ERROR_SUCCESS.
        ///  If there is no headset connected to the controller, the function will also retrieve ERROR_SUCCESS with NULL as the values for pRenderDeviceId and pCaptureDeviceId.
        ///  If the controller port device is not physically connected, the function will return ERROR_DEVICE_NOT_CONNECTED.
        ///  If the function fails, it will return a valid Win32 error code.</returns>
        [DllImport(dllPath, CharSet = CharSet.Unicode)]
        public static extern uint XInputGetAudioDeviceIds(uint dwUserIndex, string pRenderDeviceId, uint* pRenderCount,
            string pCaptureDeviceId, uint* pCaptureCount);

        /// <summary>
        /// Retrieves the battery type and charge status of a wireless controller.
        /// </summary>
        /// <param name="dwUserIndex">Index of the signed-in gamer associated with the device. Can be a value in the range 0–XUSER_MAX_COUNT − 1.</param>
        /// <param name="devType">Specifies which device associated with this user index should be queried. Must be BATTERY_DEVTYPE_GAMEPAD or BATTERY_DEVTYPE_HEADSET.</param>
        /// <param name="pBatteryInformation">Pointer to an XINPUT_BATTERY_INFORMATION structure that receives the battery information.</param>
        /// <returns></returns>
        [DllImport(dllPath)]
        public static extern uint XInputGetBatteryInformation(uint dwUserIndex, byte devType,
            XINPUT_BATTERY_INFORMATION* pBatteryInformation);


        /// <summary>
        /// Retrieves the capabilities and features of a connected controller.
        /// </summary>
        /// <param name="dwUserIndex">Index of the user's controller. Can be a value in the range 0–3. For information about how this value is determined and how the value maps to indicators on the controller.</param>
        /// <param name="dwFlags">Input flags that identify the controller type. If this value is 0, then the capabilities of all controllers connected to the system are returned. Currently, only one value is supported: XINPUT_FLAG_GAMEPAD</param>
        /// <param name="pCapabilities">Pointer to an XINPUT_CAPABILITIES structure that receives the controller capabilities.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the controller is not connected, the return value is ERROR_DEVICE_NOT_CONNECTED.
        /// If the function fails, the return value is an error code defined in WinError.h. The function does not use SetLastError to set the calling thread's last-error code.</returns>
        [DllImport(dllPath)]
        public static extern uint XInputGetCapabilities(uint dwUserIndex, uint dwFlags,
            XINPUT_CAPABILITIES* pCapabilities);


        /// <summary>
        /// Gets the sound rendering and sound capture device GUIDs that are associated with the headset connected to the specified controller.
        /// </summary>
        /// <param name="dwUserIndex">[in] Index of the user's controller. It can be a value in the range 0–3. For information about how this value is determined and how the value maps to indicators on the controller.</param>
        /// <param name="pDSoundRenderGuid">[out] Pointer that receives the GUID of the headset sound rendering device.</param>
        /// <param name="pDSoundCaptureGuid">[out] Pointer that receives the GUID of the headset sound capture device.</param>
        /// <returns>If the function successfully retrieves the device IDs for render and capture, the return code is ERROR_SUCCESS.
        /// If there is no headset connected to the controller, the function also retrieves ERROR_SUCCESS with GUID_NULL as the values for pDSoundRenderGuid and pDSoundCaptureGuid.
        /// If the controller port device is not physically connected, the function returns ERROR_DEVICE_NOT_CONNECTED.
        /// If the function fails, it returns a valid Win32 error code.</returns>
        [DllImport(dllPath)]
        public static extern uint XInputGetDSoundAudioDeviceGuids(uint dwUserIndex, GUID* pDSoundRenderGuid,
            GUID* pDSoundCaptureGuid);


        /// <summary>
        /// Retrieves a gamepad input event.
        /// </summary>
        /// <param name="dwUserIndex">[in] Index of the signed-in gamer associated with the device. Can be a value in the range 0–XUSER_MAX_COUNT − 1, or XUSER_INDEX_ANY to fetch the next available input event from any user.</param>
        /// <param name="dwReserved">[in] Reserved</param>
        /// <param name="pXinputKeystroke">[out] Pointer to an XINPUT_KEYSTROKE structure that receives an input event.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.
        /// If no new keys have been pressed, the return value is ERROR_EMPTY.
        /// If the controller is not connected or the user has not activated it, the return value is ERROR_DEVICE_NOT_CONNECTED. See the Remarks section below.
        /// If the function fails, the return value is an error code defined in Winerror.h. The function does not use SetLastError to set the calling thread's last-error code.</returns>
        [DllImport(dllPath)]
        public static extern uint XInputGetKeystroke(uint dwUserIndex, uint dwReserved,
            XINPUT_KEYSTROKE* pXinputKeystroke);


        /// <summary>
        /// Retrieves the current state of the specified controller.
        /// </summary>
        /// <param name="dwUserIndex">Index of the user's controller. Can be a value from 0 to 3. For information about how this value is determined and how the value maps to indicators on the controller</param>
        /// <param name="pState">Pointer to an XINPUT_STATE structure that receives the current state of the controller.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the controller is not connected, the return value is ERROR_DEVICE_NOT_CONNECTED.
        /// If the function fails, the return value is an error code defined in Winerror.h. The function does not use SetLastError to set the calling thread's last-error code.</returns>
        [DllImport(dllPath)]
        public static extern uint XInputGetState(uint dwUserIndex, XINPUT_STATE* pState);

        
        /// <summary>
        /// Sends data to a connected controller. This function is used to activate the vibration function of a controller.
        /// </summary>
        /// <param name="dwUserIndex">Index of the user's controller. Can be a value from 0 to 3. For information about how this value is determined and how the value maps to indicators on the controller.</param>
        /// <param name="pVibration">Pointer to an XINPUT_VIBRATION structure containing the vibration information to send to the controller.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.
        /// If the controller is not connected, the return value is ERROR_DEVICE_NOT_CONNECTED.
        /// If the function fails, the return value is an error code defined in WinError.h. The function does not use SetLastError to set the calling thread's last-error code.</returns>
        [DllImport(dllPath)]
        public static extern uint XInputSetState(uint dwUserIndex, XINPUT_VIBRATION* pVibration);
    }
}