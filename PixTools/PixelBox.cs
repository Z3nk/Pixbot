using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace PixTools
{
    public class PixelBox
    {
        public static Pixel getPixel(int X, int Y)
        {
            Bitmap b = new Bitmap(1, 1, PixelFormat.Format32bppPArgb);
            Graphics g=Graphics.FromImage(b);
            g.CopyFromScreen(new Point(X,Y),Point.Empty,new Size(1,1));
            g.Save();
            return new Pixel(b.GetPixel(0, 0).R, b.GetPixel(0, 0).G, b.GetPixel(0, 0).B, b.GetPixel(0, 0).A);
        }

        private static bool areEqualPixel(Color p,Color p2)
        {
            if (p.R == p2.R && p.G == p2.G && p.B == p2.B && p.A == p2.A)
                return true;
            return false;
        }
        public static bool isOnScreen(Bitmap imageCible)
        {

            Bitmap ecran = new Bitmap(getScreen());
            bool trouve = false;
            int y = 0;
            
            while (y < ecran.Height && !trouve)
            {
                int i = 0;
                while (i < ecran.Width && !trouve)
                {

                    if (areEqualPixel(ecran.GetPixel(i, y), imageCible.GetPixel(0, 0)))
                    {
                        bool ok = true;
                        int y2;
                        int i2=0;
                        for (y2 = 0; y2 < imageCible.Height; y2++)
                        {
                            for (i2 = 0; i2 < imageCible.Width; i2++)
                            {
                                if (!areEqualPixel(ecran.GetPixel(i + i2, y + y2), imageCible.GetPixel(i2, y2)))
                                    ok = false;
                                if (!ok) break;
                            }
                            if (!ok) break;
                        }

                        if (ok) trouve = true;
                        else
                        {
                            y += y2;
                            i += i2;
                        }
                    }
                    i++;
                }
                y++;
            }
            ecran.Dispose();
            imageCible.Dispose();
            return trouve;
            /*Bitmap ecran=new Bitmap(getScreen());
            bool trouve = false;
            for(int y=0;y<ecran.Height;y++)
                for (int i = 0; i < ecran.Width; i++)
                {                    
                    if (areEqualPixel(ecran.GetPixel(i, y), imageCible.GetPixel(0, 0)))//i 438 468
                    {
                        bool ok = true;

                            for (int y2 = 0; y2 < imageCible.Height; y2++)
                            {
                                for (int i2 = 0; i2 < imageCible.Width; i2++)
                                {
                                    if (!areEqualPixel(ecran.GetPixel(i + i2, y + y2), imageCible.GetPixel(i2, y2)))
                                        ok = false;
                                    if (!ok) break;
                                }
                                if (!ok) break;
                            }

                        if (ok)trouve=true;
                    }
                }
            ecran.Dispose();
            imageCible.Dispose();
            return trouve;*/
        }

        private static Bitmap getScreen()
        {
            Bitmap b = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(new Point(0, 0), Point.Empty, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            g.Save();
            g.Dispose();
            return b;
        }

       
    }

 
}
