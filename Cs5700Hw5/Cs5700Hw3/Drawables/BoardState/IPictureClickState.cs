using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables.BoardState
{
    public interface IPictureClickState
    {
        IPictureClickState HandleDrawableListClick();

        IPictureClickState HandlePictureBoardClick();
    }
}
