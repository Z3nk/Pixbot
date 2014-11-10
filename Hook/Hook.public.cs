using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace HookBox
{
    public partial class Hook
    {
        #region Constructeurs

        public Hook(HookType H, HookVisibility H2)
        {
            m_HookType = H;
            m_Visibility = H2;
        }

        #endregion

        #region Méthodes

        public bool Start()
        {

            if (m_HookType == HookType.KeyBoard)
                m_Proc = new HookProc(KeyProc);

            else if (m_HookType == HookType.Mouse)
                m_Proc = new HookProc(MouseProc);

            if (m_Visibility == HookVisibility.Global)
                m_Hook = SetWindowsHookEx(getHookType(m_HookType, m_Visibility), m_Proc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);

            else if (m_Visibility == HookVisibility.Local)
                m_Hook = SetWindowsHookEx(getHookType(m_HookType, m_Visibility), m_Proc, GetModuleHandle((IntPtr)0), (int)GetCurrentThreadId());

            if (m_Hook == (IntPtr)0)
            {
                //int errorCode = Marshal.GetLastWin32Error();               
                return false;
            }

            return true;
        }

        public bool Stop()
        {
            return UnhookWindowsHookEx(m_Hook);
        }

        #endregion

        #region Enums

        public enum HookType { Mouse, KeyBoard };
        public enum MouseEventType { MouseMoved, LeftButtonDown, RightButtonDown, MiddleButtonDown, LeftButtonUp, RightButtonUp, MiddleButtonUp, LeftButtonClick, RightButtonClick, MiddleButtonClick, Wheel };
        public enum KeyBoardEventType { KeyDown, KeyUp, SysKeyDown, SysKeyUp, KeyShift, KeyCapital, NumLock };
        public enum HookVisibility { Global, Local };

        #endregion

        # region Accesseurs

        public event MouseEventHandler OnMouseClick
        {
            add
            {
                m_onMouseClick += value;
            }
            remove
            {
                m_onMouseClick -= value;
            }
        }
        public event KeyPressEventHandler OnKeyPress
        {
            add
            {
                m_onKeyPress += value;
            }
            remove
            {
                m_onKeyPress -= value;
            }
        }
        public event KeyEventHandler OnKeyUp
        {
            add
            {
                m_onKeyUp += value;
            }
            remove
            {
                m_onKeyUp -= value;
            }
        }
        public event KeyEventHandler OnKeyDown
        {
            add
            {
                m_onKeyDown += value;
            }
            remove
            {
                m_onKeyDown -= value;
            }
        }

        #endregion
    }
}