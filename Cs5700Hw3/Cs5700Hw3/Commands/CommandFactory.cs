using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw3.Commands
{
    public static class CommandFactory
    {
        public static ICommand CreateCommand(Type commandType)
        {
            if (commandType.GetInterfaces().Contains(typeof(ICommand)))
            {
                return (ICommand) Activator.CreateInstance(commandType);
            }
            else
            {
                throw new ArgumentException("Invalid command type argument");
            }
        }
    }
}
