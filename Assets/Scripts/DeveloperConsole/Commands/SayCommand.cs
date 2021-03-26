using UnityEngine;

namespace Assets.Scripts.DeveloperConsole.Commands
{
    /// <summary>
    /// Writes something in the debug console
    /// </summary>
    [Command("say")]
    class SayCommand : ConsoleCommandBase
    {
        public override bool Process(string[] args)
        {
            Debug.Log(string.Join(" ", args));
            return true;
        }
    }
}
