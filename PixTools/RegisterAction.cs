using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.ComponentModel;

namespace PixTools
{
    public class RegisterAction
    {

        public List<Action> L { get; set; }
        int i = 0;
        public RegisterAction()
        {
            L = new List<Action>();
        }

        public void addKeyboardAction(string key)
        {
            L.Add(new KeyboardAction(i,key));
            i++;
        }


        public void addMouseAction(MouseEventArgs e)
        {
            L.Add(new MouseAction(i, e, true));
            i++;
        }



       

    }
}
