using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables
{
    public enum CatDrawable
    {
        Cat1,
        Cat2,
        Bed,
        Bowl,
        Mouse,
        Yarn
    }
    public static class DrawableFactory
    {
        private static readonly Dictionary<CatDrawable, IDrawable> drawables = new Dictionary<CatDrawable, IDrawable>()
        {
            { CatDrawable.Cat1, new SimpleDrawable("Assets/cat1.png", "Cat")},
            { CatDrawable.Cat2, new SimpleDrawable("Assets/cat2.png", "Sleeping Cat")},
            { CatDrawable.Bed, new SimpleDrawable("Assets/catBed.png", "Bed")},
            { CatDrawable.Bowl, new SimpleDrawable("Assets/catBowl.png", "Bowl")},
            { CatDrawable.Mouse, new SimpleDrawable("Assets/catMouse.png", "Mouse")},
            { CatDrawable.Yarn, new SimpleDrawable("Assets/catYarn.png", "Yarn")},

        };

        public static List<IDrawable> GetAllDrawables => drawables.Values.ToList();

        public static IDrawable FromReadableName(string name)
        {
            return (from kv in drawables where kv.Value.ReadableName == name select kv.Value).FirstOrDefault();
        }
        public static IDrawable GetDrawable(CatDrawable cd)
        {
            return drawables.ContainsKey(cd) ? drawables[cd] : null;
        }
    }
}
