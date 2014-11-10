using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookBox
{
    public partial class MouseControler
    {
        #region Accesseurs

        public Hook GlobalHook
        {
            get { return m_GlobalHook; }
            set { m_GlobalHook = value; }
        }
        public Hook LocalHook
        {
            get { return m_LocalHook; }
            set { m_LocalHook = value; }
        }

        #endregion

        #region Constructeurs

        public MouseControler()
        {
            m_LocalHook = new Hook(Hook.HookType.Mouse, Hook.HookVisibility.Local);
            m_GlobalHook = new Hook(Hook.HookType.Mouse, Hook.HookVisibility.Global);
        }

        #endregion

        #region Méthodes

        public void DoMouseMove(int X, int Y)
        {
            // Changer la position du curseur
            //
            SetCursorPos(X, Y);
        }

        public void DoMouseClick(ButtonType B, int X, int Y)
        {
            // Récupérer l'ancienne position du curseur
            //
            POINT pt;
            GetCursorPos(out pt);

            // Changer la position actuel du curseur
            //
            SetCursorPos(X, Y);

            // Emuler un clique a la psotion actuel du curseur
            //
            mouse_event((uint)0x0002 | 0x8000, (uint)0, (uint)0, (uint)0, (UIntPtr)0);
            mouse_event((uint)0x0004 | 0x8000, 0, 0, 0, (UIntPtr)0);

            // Remetre l'ancienne position du curseur
            //
            SetCursorPos((int)pt.x, (int)pt.y);
        }

        #endregion

        #region Enums

        public enum ButtonType { Left, Right, Middle }

        #endregion
    }
}