using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.Commands;
using Cs5700Hw3.View;

namespace Cs5700Hw3.Drawables.BoardState
{
    public abstract class PictureClickState
    {
        protected MainForm form;
        public PictureClickState(MainForm form)
        {
            this.form = form;
        }

        public abstract void HandleDrawingPanelClick(MouseEventArgs e);
    }
}
