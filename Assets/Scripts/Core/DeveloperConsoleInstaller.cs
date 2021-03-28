using Assets.Scripts.DeveloperConsole;
using System.Reflection;
using Zenject;

namespace Assets.Scripts.Core
{
    public class DeveloperConsoleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var developperConsole = new CommandHandler();
            developperConsole.LoadAssembly(Assembly.GetExecutingAssembly());
            Container.BindInstance(developperConsole);
        }
    }
}