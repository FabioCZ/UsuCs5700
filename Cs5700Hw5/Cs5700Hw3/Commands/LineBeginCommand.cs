using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class LineBeginCommand : ICommand
    {
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;
        public void Execute(CommandArgs commandArgs = null)
        {
            TargetPicture.Lines.Add(new Line(commandArgs.TargetLocation,null));
        }

        public void Undo()
        {
            TargetPicture.Lines.RemoveAt(TargetPicture.Lines.Count-1);
        }
    }
}
