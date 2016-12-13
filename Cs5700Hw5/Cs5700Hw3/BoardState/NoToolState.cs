using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.View;

namespace Cs5700Hw3.BoardState
{
    class NoToolState : PictureToolState
    {
        public NoToolState(MainForm form) : base(form)
        {
        }

        public override void HandleDrawingPanelClick(MouseEventArgs e)
        {
            if (form.PictureInfo.Background == null)
            {
                form.noPictureLabel.Text += " click click click ";
            }
        }


    }
}
