﻿using System;
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
        public bool IsSelected
        {
            get { return false;}
            set { throw new InvalidOperationException("no set for selected on simple drawable"); }
        }

        public Image Image { get; set; }
        public SimpleDrawable(string filename, string readableName)
        {
            FileName = filename;
            Image = System.Drawing.Image.FromFile(filename);
            ReadableName = readableName;
        }

        public void Draw(Graphics graphics)
        {
            throw new InvalidOperationException("no set for selected on simple drawable");
        }
    }
}
