using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables
{
    public interface IDrawable
    {
        string FileName { get; }
        string ReadableName { get; }

        Image Image { get; set; }

        void Draw(Graphics graphics);

    }
}
