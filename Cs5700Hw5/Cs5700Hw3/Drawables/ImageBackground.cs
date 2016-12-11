using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs5700Hw3.Drawables
{
    public class ImageBackground : IBackground
    {


        public string ImageFileName { get; private set; }
        private Image image;

        public ImageBackground(string imageFileName)
        {
            ImageFileName = imageFileName;
            if (!File.Exists(ImageFileName))
            {
                MessageBox.Show($@"Could not find file {ImageFileName}. Verify that is present on your computer");
            }
            image = Image.FromFile(ImageFileName);
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image,Rectangle.Round(graphics.VisibleClipBounds));
        }
    }
}
