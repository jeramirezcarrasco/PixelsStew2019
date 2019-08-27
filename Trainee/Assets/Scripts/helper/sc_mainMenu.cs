using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_mainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public string levelname;
    public void PlayGame()
    {
        SceneManager.LoadScene(levelname);
    }
    public void QuitApp()
    {
        Application.Quit();
    }

}
