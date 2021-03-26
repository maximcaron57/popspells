using Assets.Scripts.DeveloperConsole;
using Assets.Scripts.DeveloperConsole.Commands;
using NUnit.Framework;
using System.Collections;
using System.Reflection;
using UnityEngine.TestTools;

namespace Assets.Editors
{
    public class DeveloperConsoleTests
    {
        // A Test behaves as an ordinary method
        [TestCase("/say")]
        [TestCase("say")]
        [TestCase("/blep")]
        [TestCase("")]
        public void DeveloperConsoleSimpleCommandTest(string command)
        {
            var devConsole = new CommandHandler();
            devConsole.LoadAssembly(Assembly.GetAssembly(typeof(SayCommand)));

            devConsole.ProcessCommand(command);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DeveloperConsoleTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}

