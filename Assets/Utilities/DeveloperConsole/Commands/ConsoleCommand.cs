using UnityEngine;

namespace Assets.Utilities.DeveloperConsole.Commands
{
    public abstract class ConsoleCommand : IConsoleCommand
    {
        [SerializeField]
        private string _commandWord = string.Empty;
        public string CommandWord => _commandWord;
        public abstract bool Process(string[] args);
    }
}
