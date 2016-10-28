using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;

namespace Cs5700Hw3.DB
{
    public class PictureInfo
    {
        public string PictureName { get; set; }

        public DateTime Created { get; set; }

        public SolidBackground Background { get; set; }

        public override string ToString()
        {
            return PictureName + ", " + Created.ToString("g");
        }
    }
}
