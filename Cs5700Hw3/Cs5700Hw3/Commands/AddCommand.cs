using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class AddCommand : ICommand
    {
        private DrawableWithState addedDrawable;
        public PictureState TargetPicture { get; set; }
        public bool Undoable => true;

        public void Execute(CommandArgs commandArgs = null)
        {
            if (commandArgs?.Drawable != null && commandArgs?.TargetLocation != default(Point))
            {
                addedDrawable = new DrawableWithState(commandArgs.Drawable) {Location = commandArgs.TargetLocation};
                TargetPicture.Drawables.Add(addedDrawable);
            }
        }

        public void Undo()
        {
            TargetPicture.Drawables.Remove(addedDrawable);
        }
    }
}
