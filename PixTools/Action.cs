using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixTools
{
    public class Action
    {
        int valeurTemporel;
        public Action(int val)
        {
            valeurTemporel = val;
        }
    }

    public class MouseAction : Action
    {
        int X;
        int Y;
        bool pressed;
        public MouseEventArgs e;
        public MouseAction(int val, int X, int Y, bool pressed)
            : base(val)
        {
            this.X = X;
            this.Y = Y;
            this.pressed = pressed;
        }

        public MouseAction(int val, MouseEventArgs e, bool pressed)
            : base(val)
        {
            this.e = e;
            this.pressed = pressed;
        }
    }



    public class KeyboardAction : Action
    {
        public string touche;
        public KeyboardAction(int val, string touche)
            : base(val)
        {
            this.touche = touche;
        }

    }
}
