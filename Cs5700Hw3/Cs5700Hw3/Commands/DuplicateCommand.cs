using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class DuplicateCommand : ICommand
    {
        private DrawableWithState cloned;
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;

        public void Execute(CommandArgs commandArgs = null)
        {
            if (TargetPicture.SelectedDrawable != null)
            {
                cloned = TargetPicture.SelectedDrawable.Clone();
                TargetPicture.Drawables.Add(cloned);
            }
        }

        public void Undo()
        {
            TargetPicture.Drawables.Remove(cloned);
        }
    }
}
