using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class CommandArgs
    {
        public IDrawable Drawable { get; set; }
        public Point TargetLocation { get; set; }
    }
}
