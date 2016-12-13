using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class SavePicCommand : ICommand
    {
        public PictureInfo TargetPicture { get; set; }

        public bool Undoable => false;

        public void Execute(CommandArgs commandArgs = null)
        {
            if (string.IsNullOrEmpty(commandArgs.SavePictureName))
            {
                throw new ArgumentNullException("Picture name cannnot be empty");
            }
            TargetPicture.PictureName = commandArgs.SavePictureName;
            if (TargetPicture.Created == default(DateTime))
            {
                TargetPicture.Created = DateTime.Now;
            }
            FireBaseDbo.Instance.Save(TargetPicture);
        }

        public void Undo()
        {
            //nothing to do here
        }
    }
}
