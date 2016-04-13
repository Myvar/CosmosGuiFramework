using CGF.System.Internals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = (Bitmap)Image.FromFile(dlg.FileName);
                RWStream str = new RWStream();
                str.WriteInt32(bmp.Width);
                str.WriteInt32(bmp.Height);
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var px = bmp.GetPixel(x, y);
                        str.WriteInt32(((px.R << 16) | (px.G << 8) | px.B));
                    }
                }

                File.WriteAllBytes("img.cif", str._buffer.ToArray());
            }
        }
    }
}
