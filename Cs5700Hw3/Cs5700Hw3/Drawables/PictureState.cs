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

        [JsonIgnore]
        public ICommand LatestCommand { get; private set; }

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

        public bool ExecuteCommand(Type commandType, CommandArgs args = null)
        {
            var cmd = CommandFactory.CreateCommand(commandType);
            cmd.TargetPicture = this;
            LatestCommand = cmd;
            if (cmd.Undoable)
            {
                CommandHistory.Push(cmd);
            }
            else
            {
                CommandHistory.Clear();
            }
            cmd.Execute(args);
            if (cmd is OpenPicCommand || cmd is NewPicCommand)
            {
                CommandHistory.Clear();
            }
            return cmd.Undoable;
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
