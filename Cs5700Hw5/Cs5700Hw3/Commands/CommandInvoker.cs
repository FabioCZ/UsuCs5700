﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;

namespace Cs5700Hw3.Commands
{
    public class CommandInvoker
    {
        private PictureInfo pictureInfo;
        public Stack<ICommand> CommandHistory { get; set; }

        public ICommand LatestCommand { get; private set; }

        public CommandInvoker(PictureInfo pictureInfo)
        {
            CommandHistory = new Stack<ICommand>();
            this.pictureInfo = pictureInfo;
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
            cmd.TargetPicture = pictureInfo;
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
                pictureInfo = cmd.TargetPicture;
            }
            return cmd.Undoable;
        }
    }
}
