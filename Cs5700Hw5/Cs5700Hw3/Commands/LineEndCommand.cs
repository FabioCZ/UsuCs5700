﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class LineEndCommand : ICommand
    {
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;
        public void Execute(CommandArgs commandArgs = null)
        {
            var lastLine = TargetPicture.Lines.LastOrDefault();
            if (lastLine != null && !lastLine.IsFinished)
            {
                TargetPicture.Lines[TargetPicture.Lines.Count - 1].ToPoint = commandArgs.TargetLocation;
            }
        }

        public void Undo()
        {
            TargetPicture.Lines[TargetPicture.Lines.Count - 1].ToPoint = null;
        }
    }
}
