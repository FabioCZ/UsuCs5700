﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class ResizeCommand : ICommand
    {
        private DrawableWithState drawable;
        private float oldScale;
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;


        public void Execute(CommandArgs commandArgs = null)
        {
            if (commandArgs?.Scale != null)
            {
                oldScale = TargetPicture.SelectedDrawable.Scale;
                TargetPicture.SelectedDrawable.Scale = commandArgs.Scale.Value;
            }
        }

        public void Undo()
        {
            TargetPicture.SelectedDrawable.Scale = oldScale;
        }
    }
}