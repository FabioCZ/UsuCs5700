using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.View;

namespace Cs5700Hw3.Drawables.BoardState
{
    class NoPictureClickState : PictureClickState
    {
        public NoPictureClickState(MainForm form) : base(form)
        {
        }

        public override void HandleDrawingPanelClick(MouseEventArgs e)
        {
            //nothing here
        }


    }
}
