using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Maybe this class could contain everything we want to persist across scenes
public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
