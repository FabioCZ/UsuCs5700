using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Cs5700Hw3.View;

namespace Cs5700Hw3.BoardState
{
    public class AddDrawableToolState : PictureToolState
    {
        public AddDrawableToolState(MainForm form) : base(form)
        {
        }
        public override void HandleDrawingPanelClick(MouseEventArgs e)
        {
            var args = new CommandArgs()
            {
                Drawable = DrawableFactory.GetDrawable((CatDrawable)form.SelectedDrawableIndex - form.DrawavblesToolOffset),
                TargetLocation = e.Location
            };
            form.ExecuteCommand(typeof(AddCommand), args);
            form.SelectionButtonsEnabled = false;
        }


    }
}
