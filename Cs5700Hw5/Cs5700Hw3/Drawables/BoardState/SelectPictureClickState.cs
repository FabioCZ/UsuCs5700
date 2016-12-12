﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.Commands;
using Cs5700Hw3.View;

namespace Cs5700Hw3.Drawables.BoardState
{
    public class SelectPictureClickState : PictureClickState
    {
        public SelectPictureClickState(MainForm form) : base(form)
        {
        }

        public override void HandleDrawingPanelClick(MouseEventArgs e)
        {
            var args = new CommandArgs()
            {
                TargetLocation = (e).Location
            };
            form.ExecuteCommand(typeof(SelectCommand), args);
            form.HandleSelectionChange();
        }


    }
}
