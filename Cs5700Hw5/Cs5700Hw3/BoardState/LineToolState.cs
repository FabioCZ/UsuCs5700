using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.Commands;
using Cs5700Hw3.View;

namespace Cs5700Hw3.BoardState
{
    public class LineToolState : PictureToolState
    {
        public LineToolState(MainForm form) : base(form)
        {
        }

        public override void HandleDrawingPanelClick(MouseEventArgs e)
        {
            var args = new CommandArgs()
            {
                TargetLocation = e.Location
            };
            var cmdType = form.PictureInfo.IsDrawingLine ? typeof(LineEndCommand) : typeof(LineBeginCommand);
            form.ExecuteCommand(cmdType, args);
        }
    }
}
