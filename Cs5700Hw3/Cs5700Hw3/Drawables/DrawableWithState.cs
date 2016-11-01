using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cs5700Hw3.Drawables
{
    public class DrawableWithState : IDrawable
    {
        private SimpleDrawable backingdrawable;
        private float scale;
        private Bitmap map;
        private Size originalSize;
        public string FileName => backingdrawable.FileName;
        public string ReadableName => backingdrawable.ReadableName;
        public bool IsSelected { get; set; }

        public Point Location { get; set; }
        public Size Size { get; private set; }

        public float Scale
        {
            get { return scale; }
            set
            {
                if (scale < 0 || scale > 10)
                {
                    throw  new ArgumentException("bad scale");
                }
                scale = value;

            }
        }

        public DrawableWithState(IDrawable bd)
        {
            if (!(bd is SimpleDrawable))
            {
                throw new ArgumentException("Add command parameter should be a simple drawable");
            }
            backingdrawable = bd as SimpleDrawable;
            var img = System.Drawing.Image.FromFile(FileName);
            map = new Bitmap(img);
            Size = img.Size;
            originalSize = img.Size;
        }
        public void Draw(Graphics graphics)
        {
            //var x = graphics.VisibleClipBounds.Width;
            //var y = graphics.VisibleClipBounds.Height;
            //graphics.ScaleTransform(scale, scale);
            //graphics.TranslateTransform(-1*(x-graphics.VisibleClipBounds.Width),-1*(y - graphics.VisibleClipBounds.Height));
            graphics.DrawImage(map, Location);
            graphics.ResetTransform();
        }
    }
}
