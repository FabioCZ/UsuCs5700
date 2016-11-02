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
            var dialog = new NewDrawingDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                Debug.WriteLine(dialog.SelectedColor);
                if (dialog.SelectedColor != null)
                {
                    TargetPicture = new PictureInfo { Background = new SolidBackground(dialog.SelectedColor.Value) };
                }
                else
                {
                    TargetPicture = new PictureInfo { Background = new ImageBackground(dialog.FileName) };
                }
            }
        }

        public void Undo()
        {
            //nothing to do here
        }
    }
}
