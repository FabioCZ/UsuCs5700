using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables
{
    public static class DrawableFactory
    {
        private static readonly Dictionary<Type, IDrawable> drawables = new Dictionary<Type, IDrawable>()
        {
            { typeof(Cat1Drawable), new Cat1Drawable()},

        };

        public static IDrawable GetDrawable(Type t)
        {
            return drawables.ContainsKey(t) ? drawables[t] : null;
        }
    }
}
