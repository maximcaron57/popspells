using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Utilities.Inputs
{
    //Class that encompass the default values and tools to remap functions to keys.
    public class InputManager : MonoBehaviour
    {
        public enum InputNames
        {
            ForwardFunction = 0,
            BackwardFunction = 1,
            LeftFunction = 2,
            RightFunction = 3,
            ToggleConsole = 4,
        }

        private static Dictionary<InputNames, KeyCode> _KeyMapping = new Dictionary<InputNames, KeyCode>();

        // Start is called before the first frame update
        void Awake()
        {
            DontDestroyOnLoad(this);
            // Default Inputs
            _KeyMapping[InputNames.ForwardFunction]  = KeyCode.W;
            _KeyMapping[InputNames.BackwardFunction] = KeyCode.S;
            _KeyMapping[InputNames.LeftFunction]     = KeyCode.A;
            _KeyMapping[InputNames.RightFunction]    = KeyCode.D;
            _KeyMapping[InputNames.ToggleConsole]    = KeyCode.F1;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Returns the key for a given function
        public static KeyCode GetKeyCode(InputNames function) 
            => _KeyMapping.TryGetValue(function, out var value) ? value : default;

    }
}