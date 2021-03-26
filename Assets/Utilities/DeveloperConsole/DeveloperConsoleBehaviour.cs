using Assets.Utilities.DeveloperConsole.Commands;
using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.Utilities.DeveloperConsole
{
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _prefix = string.Empty;
        [SerializeField]
        private ConsoleCommandBase[] _commands = new ConsoleCommandBase[0];

        [Header("UI")]
        [SerializeField]
        private GameObject _uiCanvas = null;
        [SerializeField]
        private TMP_InputField _inputField = null;

        private float _pausedTimeScale;

        private static DeveloperConsoleBehaviour _instance;

        [Inject]
        private DeveloperConsole _developerConsole;

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

            if (!_uiCanvas.activeSelf)
            {
                _pausedTimeScale = Time.timeScale;
                Time.timeScale = 0;
                _uiCanvas.SetActive(true);
                _inputField.ActivateInputField();
                _inputField.onSubmit.AddListener(OnSubmitHandler);
            }
            else
            {
                Time.timeScale = _pausedTimeScale;
                _uiCanvas.SetActive(false);
                _inputField.onSubmit.RemoveAllListeners();
            }
        }

        private void OnSubmitHandler(string arg0)
        {
            ProcessCommand(arg0);
        }

        public void ProcessCommand(string input)
        {
            _developerConsole.ProcessCommand(input);

            _inputField.text = string.Empty;
        }
    }
}
