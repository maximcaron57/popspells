using Assets.Utilities.DeveloperConsole.Commands;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.Utilities.DeveloperConsole
{
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _prefix = string.Empty;
        [SerializeField]
        private ConsoleCommand[] _commands = new ConsoleCommand[0];

        [Header("UI")]
        [SerializeField]
        private GameObject _uiCanvas = null;
        [SerializeField]
        private TMP_InputField _inputField = null;

        private float pausedTimeScale;

        private static DeveloperConsoleBehaviour _instance;

        private DeveloperConsole _developerConsole;

        // TODO: replace with Lazy<>
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if(DeveloperConsole != null)
                {
                    return _developerConsole;
                }

                return _developerConsole = new DeveloperConsole(_prefix, _commands);
            }
        }

        private void Awake()
        {
            // if there's already an instance that isn't us
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void Toggle(CallbackContext context)
        {
            if (!context.action.triggered) return;

            if (_uiCanvas.activeSelf)
            {
                Time.timeScale = pausedTimeScale;
                _uiCanvas.SetActive(false);
            }
            else
            {
                pausedTimeScale = Time.timeScale;
                Time.timeScale = 0;
                _uiCanvas.SetActive(true);
                _inputField.ActivateInputField();
            }
        }

        public void ProcessCommand(string input)
        {
            DeveloperConsole.ProcessCommand(input);

            _inputField.text = string.Empty;
        }
    }
}
