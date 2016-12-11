using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public class MoveCommand : ICommand
    {
        private Point oldPosition;
        private MoveDirection direction;
        public PictureState TargetPicture { get; set; }
        public bool Undoable => true;

        public void Execute(CommandArgs commandArgs = null)
        {
            if (commandArgs?.Direction != null)
            {
                oldPosition = TargetPicture.SelectedDrawable.Location;
                var tmp = oldPosition;
                switch (commandArgs.Direction.Value)
                {
                    case MoveDirection.Up:
                        tmp.Y -= 5;
                        break;
                    case MoveDirection.Right:
                        tmp.X += 5;
                        break;
                    case MoveDirection.Down:
                        tmp.Y += 5;
                        break;
                    case MoveDirection.Left:
                        tmp.X -= 5;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                TargetPicture.SelectedDrawable.Location = tmp;
            }

        }

        public void Undo()
        {
            TargetPicture.SelectedDrawable.Location = oldPosition;
        }
    }
}
