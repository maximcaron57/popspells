using UnityEngine;

namespace Assets.Utilities.DeveloperConsole.Commands
{
    public abstract class ConsoleCommandBase : IConsoleCommand
    {
        public abstract bool Process(string[] args);
    }
}
