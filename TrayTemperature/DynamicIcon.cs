using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace TrayTemperature
{
    class DynamicIcon
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);

        //Creates a 16x16 icon with 2 lines of  text
        public static Icon CreateIcon(string Line1Text, Color Line1Color
            , string Line2Text, Color Line2Color)
        {
            //Font font = new Font("Consolas", 7);
            //Font font = new Font("Arial", 7);
            Bitmap bitmap = new Bitmap(16, 16);

            Graphics graph = Graphics.FromImage(bitmap);

            graph.TextRenderingHint = TextRenderingHint.AntiAlias;
            Pen pen = new Pen(Color.Black, 1); // Adjust the pen width as needed
            Font font = new Font("Arial", 7, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Line1Color);

            //Draw the temperatures
            //graph.DrawString(Line1Text, font, new SolidBrush(Line1Color), new PointF(-1, -3));
            //graph.DrawString(Line2Text, font, new SolidBrush(Line2Color), new PointF(-1, 7));

            graph.DrawString(Line1Text, font, brush, new PointF(-1, 2));

            IntPtr ico = bitmap.GetHicon();
            Icon bitmapIcon = Icon.FromHandle(ico);


            return bitmapIcon;
        }
    }
}
