namespace Assets.Scripts.DeveloperConsole.Commands
{
    public interface IConsoleCommand
    {
        bool Process(string[] args);
    }
}
