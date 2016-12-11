using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.Commands
{
    public static class CommandFactory
    {
        public static ICommand CreateCommand(Type commandType)
        {
            if (commandType.GetInterfaces().Contains(typeof(ICommand)))
            {
                var cmd =  (ICommand) Activator.CreateInstance(commandType);
                return cmd;
            }
            else
            {
                throw new ArgumentException("Invalid command type argument");
            }
        }
    }
}
