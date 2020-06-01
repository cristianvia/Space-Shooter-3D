using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefsManager.initialize();
    }
    public void LoadScores()
    {
        SceneManager.LoadScene("ScoresMenu");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void LoadPlay()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
