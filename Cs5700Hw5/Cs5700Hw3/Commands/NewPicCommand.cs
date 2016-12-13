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
    public class NewPicCommand : ICommand 
    {
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => false;
            
        public void Execute(CommandArgs commandArgs = null)
        {
            
                if (commandArgs.BackgroundColor != null)
                {
                    TargetPicture = new PictureInfo { Background = new SolidBackground(commandArgs.BackgroundColor.Value) };
                }
                else if (string.IsNullOrEmpty(commandArgs.BackgroundFileName))
                {
                    TargetPicture = new PictureInfo { Background = new ImageBackground(commandArgs.BackgroundFileName) };
                }
                else
                {
                    throw new ArgumentNullException("Either color or background filename must be specified when creating a new PictureInfo");
                }
        }

        public void Undo()
        {
            //nothing to do here
        }
    }
}
