using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cs5700Hw3.Drawables
{
    public class Line
    {
        public Point FromPoint { get; set; }
        public Point? ToPoint { get; set; }
        [JsonIgnore]
        public bool IsFinished => ToPoint != null;

        private Pen linePen;
        private Brush lineBoxBrush;

        public Line(Point fromPoint, Point? toPoint)
        {
            FromPoint = fromPoint;
            ToPoint = toPoint;
            linePen = new Pen(Color.Black, 4.0f);
            lineBoxBrush = new SolidBrush(Color.DarkGray);
        }

        public void Draw(Graphics graphics)
        {
            if (IsFinished)
            {
                graphics.DrawLine(linePen, FromPoint, ToPoint.Value);
            }
            else
            {
                graphics.FillRectangle(lineBoxBrush, new Rectangle(FromPoint.X - 5, FromPoint.Y - 5, 10, 10));
            }
        }
    }
}
