using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Utilities.DeveloperConsole
{
    public class DeveloperConsole
    {
        private readonly string _prefix;
        private readonly Dictionary<string, IConsoleCommand> _commands;

        public DeveloperConsole(string prefix, IEnumerable<IConsoleCommand> commands)
        {
            _prefix = prefix;
            _commands = commands.ToDictionary(x => x.CommandWord);
        }

        public void ProcessCommand(string commandInput, string[] args)
        {
            _commands.TryGetValue(commandInput, out IConsoleCommand command);
            command?.Process(args);
        }

        public void ProcessCommand(string inputValue)
        {
            if (!inputValue.StartsWith(_prefix)) return;

            inputValue.Remove(0, _prefix.Length);

            string[] inputSplit = inputValue.Split(' ');

            string commandInput = inputSplit[0];
            var args = inputSplit.Skip(1).ToArray();

            ProcessCommand(commandInput, args);
        }
    }
}
