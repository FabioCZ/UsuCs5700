using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;
using Cs5700Hw3.View;

namespace Cs5700Hw3.Commands
{
    public class OpenPicCommand : ICommand
    {
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => false;

        public void Execute(CommandArgs commandArgs = null)
        {
            if (commandArgs.PictureToOpen == null)
            {
                throw new ArgumentNullException("Internal Error openning PictureInfo: no PictureInfo specified (null)");
            }
            TargetPicture = commandArgs.PictureToOpen;
        }

        public void Undo()
        {
            //nothing here
        }
    }
}
