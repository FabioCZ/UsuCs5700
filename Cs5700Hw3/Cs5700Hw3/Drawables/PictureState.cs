using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Commands;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;

namespace Cs5700Hw3.Drawables
{
    public class PictureState
    {
        public string PictureName { get; set; }

        public DateTime Created { get; set; }

        [JsonConverter(typeof(BackgroundJsonConverter))]
        public IBackground Background { get; set; }

        [JsonConverter(typeof(DrawableJsonConverter))]
        public List<DrawableWithState> Drawables { get; set; }

        [JsonIgnore]
        public DrawableWithState SelectedDrawable { get; set; }

        [JsonIgnore]
        public Stack<ICommand> CommandHistory { get; set; }

        public PictureState()
        {
            Drawables = new List<DrawableWithState>();
            CommandHistory = new Stack<ICommand>();
        }

        public void Draw(Graphics graphics)
        {
            Background.Draw(graphics);
            foreach (var drawable in Drawables)
            {
                drawable.Draw(graphics);
            }
        }

        /// <summary>
        /// Returns tru if there is a next undo available
        /// </summary>
        /// <returns></returns>
        public bool Undo()
        {
            if (CommandHistory.Any())
            {
                var command = CommandHistory.Pop();
                command.Undo();
            }
            return CommandHistory.Any() && CommandHistory.Peek().Undoable;
        }

        public void ExecuteCommand(ICommand command, CommandArgs args)
        {
            command.TargetPicture = this;
            if (command.Undoable)
            {
                CommandHistory.Push(command);
            }
            else
            {
                CommandHistory.Clear();
            }
            command.Execute(args);
            if (command is OpenPicCommand || command is NewPicCommand)
            {
                CommandHistory.Clear();
            }
        }

        public override string ToString()
        {
            return PictureName + ", " + Created.ToString("g");
        }

        public DrawableWithState FindDrawableAtPoint(Point location) => Drawables.FindLast(d => location.X >= d.Location.X &&
                                              location.X < d.Location.X + d.Size.Width &&
                                              location.Y >= d.Location.Y &&
                                              location.Y < d.Location.Y + d.Size.Height);
    }
}
