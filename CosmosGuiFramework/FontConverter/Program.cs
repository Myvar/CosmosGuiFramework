using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontConverter
{
    class Program
    {

        static List<char> chars = new List<char>();


        static void Main(string[] args)
        {
            // header:
            //magic number: CFF - Custom Font File
            // Font name : string
            // font style : byte
            // font size : short
            // charcounts: int

            //body
            //charindex []
            // charcode asci
            // char Width
            // char Height
            // char data

            for (char c = (char)33; c <= (char)126; ++c)
            {
                chars.Add(c);
            }
     
            Console.WriteLine("Total fonts: " + FontFamily.Families.Count());
            Console.Write("Char Index :");
            Console.WriteLine(chars.ToArray());

            List<Thread> fontAcs = new List<Thread>();

            Build(new Font("consolas", 14).FontFamily);

         /*   foreach (FontFamily font in FontFamily.Families)
            {

                fontAcs.Add(new Thread(() => {
                   
                        Build(font);
                   
                    Thread.CurrentThread.Abort();

                }
                ));

            }

            for (int z = 1; z < 8; z++)
            {
                for (int i = 0; i < fontAcs.Count() / 8; i++)
                {
                    fontAcs[(fontAcs.Count() / 8 * z) + i].Start();
                }
                while (fontAcs.Where((x) => { return x.IsAlive; })?.Count() != 0)
                {

                }
            }*/
        }

        public static void Build(FontFamily font)
        {
            // header:
            //magic number: CFF - Custom Font File
            // Font name : string
            // font style : byte
            // font size : short
            // charcounts: int

            //body
            //charindex []
            // charcode asci
            // char Width
            // char Height
            //short data lenth
            // char data

            Stopwatch sw = new Stopwatch();
            sw.Start();
         
            for (int s = 1; s < 73; s++)
            {
                CFFStream str = new CFFStream();

                str.WriteString("CFF"); // Magic number
                str.WriteString(font.Name);
                str.WriteByte(0);// TODO Add rendering suport for styles
                str.WriteInt32((short)s);
                str.WriteInt32(chars.Count);

                foreach (var i in chars)
                {


                    var size = GetFontSize(font, FontStyle.Regular, s, i.ToString());

                    Bitmap m = new Bitmap(size.Width, size.Height);
                    using (var g = Graphics.FromImage(m))
                    {
                        //g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), size));
                        g.DrawString(i.ToString(), new Font(font, s), Brushes.Black, new Point(0, 0));
                    }

                    byte[] data = new byte[size.Width * size.Height];

                    int c = 0;
                    for (int y = 0; y < m.Height; y++)
                    {
                        for (int x = 0; x < m.Width; x++)
                        {
                            //0 = transpaernt
                            //1 = pixel (when rendering font draw color in here)

                            data[c] = (byte)(m.GetPixel(x, y).A != 255 ? 0 : 1);

                            c++;
                        }
                    }


                    str.WriteByte((byte)i);
                    str.WriteByte((byte)size.Width);
                    str.WriteByte((byte)size.Height);

                    str.WriteInt32((size.Width * size.Height));
                    foreach (var xy in data)
                    {
                        str.WriteByte(xy);
                    }

                    File.WriteAllBytes(Path.Combine("Fonts", font.Name.Replace(" ", "") + s + ".cff"), str._buffer.ToArray());
                }


            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("It tool " + sw.Elapsed + " ms to Generate the font, " + font.Name);



           // File.WriteAllText("Fonts\\" + font.Name.Replace(" ", "") + ".cs", Properties.Resources.Template.Replace("::Name::", font.Name.Replace(" ", "")).Replace("::RawData::", b.ToString()));

        }




        static Size GetFontSize(FontFamily f, FontStyle fs, int size, string c)
        {
            using (Graphics g = Graphics.FromImage(new Bitmap(10, 10)))
            {
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(c, new Font(f.Name, size, fs));
                // This will give you string width, from which you can calculate further 

                return new Size(Convert.ToInt32(stringSize.Width), Convert.ToInt32(stringSize.Height));
            }
        }


    }
}
