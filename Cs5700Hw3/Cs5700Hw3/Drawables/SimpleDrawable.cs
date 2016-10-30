using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables
{
    public class SimpleDrawable : IDrawable
    {
        public string FileName { get; }
        public string ReadableName { get; }
        public bool IsSelected { get; set; }

        public SimpleDrawable(string filename, string readableName)
        {
            FileName = filename;
            ReadableName = readableName;
        }

        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
