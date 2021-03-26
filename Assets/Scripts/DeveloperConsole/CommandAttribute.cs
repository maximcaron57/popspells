using System;

namespace Assets.Scripts.DeveloperConsole
{
    public class CommandAttribute : Attribute
    {
        public CommandAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
