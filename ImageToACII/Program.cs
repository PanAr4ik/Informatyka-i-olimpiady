using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ImageToACII_Main
{
    internal class Program
    {
        private const double WIDTH_OFFSET = 2.0;

        [STAThread]
        static void Main(string[] args)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.JPEG; *.jpg; *.png; *.tiff"
            };

            while (true)
            {
                Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;
                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = bitmapResize(bitmap);
                bitmap.ToGreyScale();

                var converter = new BitmapToASCII_Convertor(bitmap);
                var rows = converter.Convert();

                foreach (var row in rows)
                {
                    Console.WriteLine(row);
                }
                Console.SetCursorPosition(0, 0);
                File.WriteAllLines("image.txt", rows.Select(r => new string(r)));
            }
        }
        private static Bitmap bitmapResize(Bitmap bitmap)
        {
            var maxWidth = 350;
            var newHeight = bitmap.Height / WIDTH_OFFSET * maxWidth / bitmap.Width;
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
            return bitmap;
        }


        
    }

    
        
}
