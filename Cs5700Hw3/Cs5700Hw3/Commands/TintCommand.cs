using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class TintCommand : ICommand
    {
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;
        public void Execute(CommandArgs commandArgs = null)
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
