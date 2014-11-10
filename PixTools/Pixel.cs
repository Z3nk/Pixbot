using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixTools
{
    public class Pixel
    {
        public byte R { get; set; }
        public byte B { get; set; }
        public byte G { get; set; }
        public byte A { get; set; }
        public Pixel(byte R, byte G, byte B, byte A)
        {
            this.R = R;
            this.B = B;
            this.G = G;
            this.A = A;
        }

         public string toString()
        {
            return string.Format("Rouge : {0}, Vert : {1}, Bleu : {2}, Alpha : {3}", R, G, B, A);
        }
    }
}
