using System;
using System.Runtime.InteropServices;

namespace HookBox
{
    public partial class MouseControler
    {
        #region Attributs

        private Hook m_GlobalHook;
        private Hook m_LocalHook;

        #endregion

        #region Imports

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        #endregion

        #region Structs

        public struct POINT
        {
            public int x;
            public int y;
        }

        #endregion
    }
}