using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void OnPlay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void OnOptions()
        {

        }

        public void OnQuit()
        {
            Debug.Log("Quitting the application.");
            Application.Quit();
        }
    }
}

