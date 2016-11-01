using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables
{
    public class DrawableWithState : IDrawable
    {
        private SimpleDrawable backingdrawable;
        public string FileName => backingdrawable.FileName;
        public string ReadableName => backingdrawable.ReadableName;
        public bool IsSelected { get; set; }

        public Image Image { get; private set; }
        public Point Location { get; set; }

        public DrawableWithState(IDrawable bd)
        {
            if (!(bd is SimpleDrawable))
            {
                throw new ArgumentException("Add command parameter should be a simple drawable");
            }
            backingdrawable = bd as SimpleDrawable;
            Image = System.Drawing.Image.FromFile(FileName);
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, Location);
        }
    }
}
