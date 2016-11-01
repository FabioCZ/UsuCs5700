﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;

namespace Cs5700Hw3.Drawables
{
    public class PictureInfo
    {
        public string PictureName { get; set; }

        public DateTime Created { get; set; }

        [JsonConverter(typeof(BackgroundJsonConverter))]
        public IBackground Background { get; set; }

        [JsonConverter(typeof(DrawableJsonConverter))]
        public List<DrawableWithState> Drawables { get; set; }

        [JsonIgnore]
        public DrawableWithState SelectedDrawable { get; set; }

        public PictureInfo()
        {
            Drawables = new List<DrawableWithState>();
        }

        public void Draw(Graphics graphics)
        {
            Background.Draw(graphics);
            foreach (var drawable in Drawables)
            {
                drawable.Draw(graphics);
            }
        }
        public override string ToString()
        {
            return PictureName + ", " + Created.ToString("g");
        }


        public DrawableWithState FindDrawableAtPoint(Point location) => Drawables.FindLast(d => location.X >= d.Location.X &&
                                              location.X < d.Location.X + d.Size.Width &&
                                              location.Y >= d.Location.Y &&
                                              location.Y < d.Location.Y + d.Size.Height);
    }
}
