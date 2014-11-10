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
        #region Attributs

        private IntPtr m_Hook = (IntPtr)0;
        private HookVisibility m_Visibility;
        private HookType m_HookType;
        private HookProc m_Proc;
        private MouseEventHandler m_onMouseClick;
        private KeyPressEventHandler m_onKeyPress;
        private KeyEventHandler m_onKeyUp;
        private KeyEventHandler m_onKeyDown;

        #endregion

        #region Déléguées

        private delegate IntPtr HookProc(int nCode, int wParam, IntPtr lParam);

        # endregion

        # region Imports

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, int dwThreadId);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(String lpModuleName);

        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetCurrentThreadId();

        [DllImport("user32")]
        private static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        [DllImport("user32")]
        private static extern int GetKeyboardState(byte[] pbKeyState);

        # endregion

        # region Structs

        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseLLHookStruct
        {
            /// <summary>
            /// Structure POINT.
            /// </summary>
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class KeyboardHookStruct
        {
            /// <summary>
            /// Key code virtuel, la valeur doit etre entre 1 et 254.
            /// </summary>
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        #endregion

        #region Méthodes privées

        private int getHookType(HookType H, HookVisibility V)
        {
            if (H == HookType.Mouse && V == HookVisibility.Local)
                return 7;

            if (H == HookType.Mouse && V == HookVisibility.Global)
                return 14;

            if (H == HookType.KeyBoard && V == HookVisibility.Local)
                return 2;

            if (H == HookType.KeyBoard && V == HookVisibility.Global)
                return 13;

            else return -1;
        }

        private int getMouseEventType(MouseEventType M)
        {
            if (M == MouseEventType.MouseMoved)
                return 0x200;

            if (M == MouseEventType.LeftButtonDown)
                return 0x201;

            if (M == MouseEventType.LeftButtonUp)
                return 0x202;

            if (M == MouseEventType.LeftButtonClick)
                return 0x203;

            if (M == MouseEventType.RightButtonDown)
                return 0x204;

            if (M == MouseEventType.RightButtonUp)
                return 0x205;

            if (M == MouseEventType.RightButtonClick)
                return 0x206;

            if (M == MouseEventType.MiddleButtonDown)
                return 0x207;

            if (M == MouseEventType.MiddleButtonUp)
                return 0x208;

            if (M == MouseEventType.MiddleButtonClick)
                return 0x209;

            if (M == MouseEventType.Wheel)
                return 0x020A;

            else return -1;
        }

        private int getKeyBoardEventType(KeyBoardEventType K)
        {
            if (K == KeyBoardEventType.KeyDown)
                return 0x100;

            if (K == KeyBoardEventType.KeyUp)
                return 0x101;

            if (K == KeyBoardEventType.SysKeyDown)
                return 0x104;

            if (K == KeyBoardEventType.SysKeyUp)
                return 0x105;

            if (K == KeyBoardEventType.KeyShift)
                return 0x10;

            if (K == KeyBoardEventType.KeyCapital)
                return 0x14;

            if (K == KeyBoardEventType.NumLock)
                return 0x90;

            else return -1;
        }

        private IntPtr KeyProc(int nCode, int wParam, IntPtr lParam)
        {
            bool handled = false;
            //On verifie si tous est ok
            if ((nCode >= 0) && (m_onKeyDown != null || m_onKeyUp != null || m_onKeyPress != null))
            {
                //Remplissage de la structure KeyboardHookStruct a partir d'un pointeur
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                //KeyDown
                if (m_onKeyDown != null && (wParam == 0x100 || wParam == 0x104))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    m_onKeyDown(this, e);
                    handled = handled || e.Handled;
                }

                // KeyPress
                if (m_onKeyPress != null && wParam == 0x100)
                {
                    // Si la touche Shift est appuyée
                    bool isShift = ((GetKeyState(0x10) & 0x80) == 0x80 ? true : false);
                    // Si la touche CapsLock est appuyée
                    bool isCapslock = (GetKeyState(0x14) != 0 ? true : false);

                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode,
                              MyKeyboardHookStruct.scanCode,
                              keyState,
                              inBuffer,
                              MyKeyboardHookStruct.flags) == 1)
                    {
                        char key = (char)inBuffer[0];
                        if ((isCapslock ^ isShift) && Char.IsLetter(key))
                            key = Char.ToUpper(key);
                        KeyPressEventArgs e = new KeyPressEventArgs(key);
                        m_onKeyPress(this, e);
                        handled = handled || e.Handled;
                    }
                }

                // KeyUp
                if (m_onKeyUp != null && (wParam == 0x101 || wParam == 0x105))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    m_onKeyUp(this, e);
                    handled = handled || e.Handled;
                }

            }

            // si handled est a true, on ne transmet pas le message au destinataire
            if (handled)
                return (IntPtr)1;
            else
            {
                try
                {
                    return CallNextHookEx(m_Hook, nCode, (IntPtr)wParam, (IntPtr)lParam);
                }
                catch(Exception e)
                {
                    return (IntPtr)1; 
                }
            }
        }

        private IntPtr MouseProc(int nCode, int wParam, IntPtr lParam)
        {
            bool processNextHook = true;

            // Verifions si nCode est different de 0 et que nos evenements sont bien attachés
            if ((nCode >= 0) && (m_onMouseClick != null))
            {
                //Remplissage de la structure MouseLLHookStruct a partir d'un pointeur
                MouseLLHookStruct mouseHookStruct = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

                //Detection du bouton clicker
                MouseButtons button = MouseButtons.None;

                switch (wParam)
                {

                    case 0x201:
                        button = MouseButtons.Left;
                        break;

                    case 0x204:
                        button = MouseButtons.Right;
                        break;
                }

                //parametre de notre event
                MouseEventArgs e = new MouseEventArgs(button, 1, mouseHookStruct.pt.x, mouseHookStruct.pt.y, 0);

                //On appelle notre event
                m_onMouseClick(this, e);
            }



            //Si processNextHook == true alors on transmet le click au destinataire, sinon, on le garde pour nous (
            if (processNextHook == true)
            {
                return CallNextHookEx((IntPtr)m_Hook, nCode, (IntPtr)wParam, (IntPtr)lParam);
            }
            else
                return (IntPtr)1;

        }

        #endregion
    }
}