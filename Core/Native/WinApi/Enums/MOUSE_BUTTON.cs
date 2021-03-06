﻿namespace Ax.Engine.Core.Native
{
    public static partial class WinApi
    {
        /// <summary>
        ///  The status of the mouse buttons.
        /// </summary>
        public enum MOUSE_BUTTON : uint
        {
            /// <summary>
            ///  The leftmost mouse button.
            /// </summary>
            FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001,

            /// <summary>
            ///  The second button from the left.
            /// </summary>
            FROM_LEFT_2ND_BUTTON_PRESSED = 0x0004,

            /// <summary>
            ///  The third button from the left.
            /// </summary>
            FROM_LEFT_3RD_BUTTON_PRESSED = 0x0008,

            /// <summary>
            ///  The fourth button from the left.
            /// </summary>
            FROM_LEFT_4TH_BUTTON_PRESSED = 0x0010,

            /// <summary>
            ///  The rightmost mouse button.
            /// </summary>
            RIGHTMOST_BUTTON_PRESSED = 0x0002,

            /// <summary>
            ///  The mouse wheel (up).
            /// </summary>
            WHEEL_UP = 7864320,

            /// <summary>
            ///  The mouse wheel (down).
            /// </summary>
            WHEEL_DOWN = 4287102976
        }
    }
}
