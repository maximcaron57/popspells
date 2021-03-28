using Assets.Utilities.DeveloperConsole;
using System.Reflection;
using Zenject;

public class DeveloperConsoleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var developperConsole = new DeveloperConsole();
        developperConsole.LoadAssembly(Assembly.GetExecutingAssembly());
        Container.BindInstance(developperConsole);
    }
}