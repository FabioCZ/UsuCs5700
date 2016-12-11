using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables
{
    public class SolidBackground : IBackground
    {
        public Color Color { get; private set; }
        private Brush brush;
        public SolidBackground(Color color)
        {
            Color = color;
            brush = new SolidBrush(Color);
        }


        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush,graphics.ClipBounds);
        }
    }
}
