using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;

namespace Cs5700Hw3.Commands
{
    public class DuplicateCommand : ICommand
    {
        public PictureInfo TargetPicture { get; set; }
        public void Execute(CommandArgs commandArgs = null)
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
