using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public interface ICommand
    {
        PictureInfo TargetPicture { get; set; }

        void Execute(CommandArgs commandArgs = null);

        void Undo();
    }
}
