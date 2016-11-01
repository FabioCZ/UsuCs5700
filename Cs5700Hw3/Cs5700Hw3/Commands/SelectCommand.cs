using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class SelectCommand : ICommand
    {
        private DrawableWithState selection;
        private DrawableWithState previousSelection;
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;
        public void Execute(CommandArgs commandArgs = null)
        {
            if (commandArgs?.TargetLocation != default(Point))
            {
                selection = TargetPicture.FindDrawableAtPoint(commandArgs.TargetLocation);
                if (selection != null)
                {
                    previousSelection = TargetPicture.Drawables.FirstOrDefault(d => d.IsSelected);
                    if (previousSelection != null)
                    {
                        previousSelection.IsSelected = false;
                    }
                    selection.IsSelected = true;
                    TargetPicture.SelectedDrawable = selection;
                }
                else
                {
                    TargetPicture.SelectedDrawable.IsSelected = false;
                    TargetPicture.SelectedDrawable = null;
                }
            }
            
        }

        public void Undo()
        {
            selection.IsSelected = false;
            if (previousSelection != null)
            {
                previousSelection.IsSelected = true;
                TargetPicture.SelectedDrawable = previousSelection;
            }
        }
    }
}
