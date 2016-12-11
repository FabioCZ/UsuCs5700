using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Drawables.BoardState
{
    class NoPictureClickState : IPictureClickState
    {
        //This will never get called since the drawables selection pane should be disabled with no picture selected
        public IPictureClickState HandleDrawableListClick()
        {
            return this;
        }

        public IPictureClickState HandlePictureBoardClick()
        {
            return this;
        }
    }
}
