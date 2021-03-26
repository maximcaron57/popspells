using System;

namespace Assets.Utilities.DeveloperConsole
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
