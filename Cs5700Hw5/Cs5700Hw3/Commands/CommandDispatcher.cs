using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;

namespace Cs5700Hw3.Commands
{
    public class CommandDispatcher
    {
        private PictureState pictureState;
        [JsonIgnore]
        public Stack<ICommand> CommandHistory { get; set; }

        [JsonIgnore]
        public ICommand LatestCommand { get; private set; }

        public CommandDispatcher(PictureState pictureState)
        {
            CommandHistory = new Stack<ICommand>();
            this.pictureState = pictureState;
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
            cmd.TargetPicture = pictureState;
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
                pictureState = cmd.TargetPicture;
            }
            return cmd.Undoable;
        }
    }
}
