using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using Pen = System.Drawing.Pen;

namespace Cs5700Hw3.Drawables
{
    public class DrawableWithState : IDrawable
    {
        private SimpleDrawable backingdrawable;
        private float scale;
        private Pen selectionPen = new Pen(System.Drawing.Color.DarkGray,2.0f);
        private Size originalSize;
        public string FileName => backingdrawable.FileName;
        public string ReadableName => backingdrawable.ReadableName;
        [JsonIgnore]
        public Bitmap Map { get; set; }
        [JsonIgnore] 
        public Image Image { get { return backingdrawable.Image; } set { backingdrawable.Image = value; } }
        public bool IsSelected { get; set; }

        public Point Location { get; set; }
        public Size Size { get; private set; }

        public float Scale
        {
            get { return scale; }
            set
            {
                if (value <= 0 || value > 10) return;
                scale = value;
                var newSize = new Size(Convert.ToInt32(originalSize.Width*scale), Convert.ToInt32(originalSize.Height*scale));
                if (Size != newSize)
                {
                    Size = newSize;
                    Map = new Bitmap(backingdrawable.Image,Size);
                }
            }
        }

        public DrawableWithState(IDrawable bd)
        {
            if (!(bd is SimpleDrawable))
            {
                throw new ArgumentException("Add command parameter should be a simple drawable");
            }
            backingdrawable = bd as SimpleDrawable;
            scale = 1.0f;
            Map = new Bitmap(backingdrawable.Image);
            Size = backingdrawable.Image.Size;
            originalSize = backingdrawable.Image.Size;
        }

        public void Draw(Graphics graphics)
        {
            if (IsSelected)
            {
                graphics.DrawRectangle(selectionPen,Location.X,Location.Y,Map.Width,Map.Height);
            }
            graphics.DrawImage(Map, Location);

        }

        public DrawableWithState Clone()
        {
            var drw = new DrawableWithState(backingdrawable);
            drw.Scale = scale;
            drw.Location = new Point(10,10);
            drw.Map = Map;
            return drw;
        }

    }
}
