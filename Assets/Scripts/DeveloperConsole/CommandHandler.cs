using Assets.Scripts.DeveloperConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts.DeveloperConsole
{
    public class CommandHandler
    {
        private readonly string _prefix;
        private readonly Dictionary<string, IConsoleCommand> _commands = new Dictionary<string, IConsoleCommand>();

        public CommandHandler()
        {
            _prefix = "/";
        }

        public void LoadAssembly(Assembly assembly)
        {
            var types = GetTypesWithAttribute<CommandAttribute>(assembly);

            foreach(var type in types)
            {
                var instance = (IConsoleCommand)Activator.CreateInstance(type);
                var attribute = type.GetCustomAttribute<CommandAttribute>();
                
                _commands.Add(attribute.Name, instance);
            }
        }

        IEnumerable<Type> GetTypesWithAttribute<T>(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        public void ProcessCommand(string commandInput, string[] args)
        {
            _commands.TryGetValue(commandInput, out IConsoleCommand command);
            command?.Process(args);
        }

        public void ProcessCommand(string inputValue)
        {
            if (!inputValue.StartsWith(_prefix)) return;

            inputValue = inputValue.Remove(0, _prefix.Length);

            string[] inputSplit = inputValue.Split(' ');

            string commandInput = inputSplit[0];
            var args = inputSplit.Skip(1).ToArray();

            ProcessCommand(commandInput, args);
        }
    }
}
