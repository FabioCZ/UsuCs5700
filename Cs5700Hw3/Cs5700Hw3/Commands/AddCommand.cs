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
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;

        public void Execute(CommandArgs commandArgs = null)
        {
            if (commandArgs?.Drawable != null && commandArgs?.TargetLocation != default(Point))
            {

                TargetPicture.Drawables.Add(new DrawableWithState(commandArgs.Drawable) {Location = commandArgs.TargetLocation});
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
