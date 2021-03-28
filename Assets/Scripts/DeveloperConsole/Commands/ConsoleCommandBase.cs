namespace Assets.Scripts.DeveloperConsole.Commands
{
    public abstract class ConsoleCommandBase : IConsoleCommand
    {
        public abstract bool Process(string[] args);
    }
}
