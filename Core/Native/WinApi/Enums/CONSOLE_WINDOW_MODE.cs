﻿namespace Ax.Engine.Core.Native
{
    public static partial class WinApi
    {
        /// <summary>
        ///  The window mode of the console. 
        /// </summary>
        public enum CONSOLE_WINDOW_MODE
        {
            /// <summary>
            ///  Text is displayed in full-screen mode.
            /// </summary>
            CONSOLE_FULLSCREEN_MODE = 1,

            /// <summary>
            ///  Text is displayed in a console window.
            /// </summary>
            CONSOLE_WINDOWED_MODE = 2
        }
    }
}
