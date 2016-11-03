using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.Drawables;
using Cs5700Hw3.View;

namespace Cs5700Hw3.Commands
{
    public class TintCommand : ICommand
    {
        private Bitmap oldMap;
        public PictureInfo TargetPicture { get; set; }
        public bool Undoable => true;
        public void Execute(CommandArgs commandArgs = null)
        {
            if (TargetPicture.SelectedDrawable != null)
            {
                var form = new TintForm();
                var res= form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    oldMap = TargetPicture.SelectedDrawable.Map;
                    TargetPicture.SelectedDrawable.Map = oldMap.ColorTint(form.Red, form.Green, form.Blue);
                }
            }
        }

        public void Undo()
        {
            TargetPicture.SelectedDrawable.Map = oldMap;
        }
    }
}
