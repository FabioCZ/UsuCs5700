using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class RemoveCommand : ICommand
    {
        private DrawableWithState deleted;
        public PictureState TargetPicture { get; set; }
        public bool Undoable => true;

        public void Execute(CommandArgs commandArgs = null)
        {
            deleted = TargetPicture.SelectedDrawable;
            TargetPicture.Drawables.Remove(TargetPicture.SelectedDrawable);
            TargetPicture.SelectedDrawable = null;
        }

        public void Undo()
        {
            TargetPicture.Drawables.Add(deleted);
        }
    }
}
