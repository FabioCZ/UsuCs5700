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
        public PictureState TargetPicture { get; set; }
        public bool Undoable => false;
            
        public void Execute(CommandArgs commandArgs = null)
        {
            
                if (commandArgs.BackgroundColor != null)
                {
                    TargetPicture = new PictureState { Background = new SolidBackground(commandArgs.BackgroundColor.Value) };
                }
                else if (string.IsNullOrEmpty(commandArgs.BackgroundFileName))
                {
                    TargetPicture = new PictureState { Background = new ImageBackground(commandArgs.BackgroundFileName) };
                }
                else
                {
                    throw new ArgumentNullException("Either color or background filename must be specified when creating a new PictureState");
                }
        }

        public void Undo()
        {
            //nothing to do here
        }
    }
}
