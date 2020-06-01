using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // This variable is public so any other class can check if the game is paused or not
    public static bool GameIsPaused = false;
    // The canvas that makes the pause menu
    public GameObject pauseMenuUI;
    // The canvas that makes the die menu
    public GameObject diedMenuUI;
    // The canvas that opens the scores menu
    public GameObject scoresMenuUI;
    // The canvas that opens the settings menu
    public GameObject settingsMenuUI;

    public GameObject pauseButton;
    // the level that will rebuild after die
    public string level = "LevelBase";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    // Hide the pause menu and resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }
    // Pause the game and show the pause menu
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseButton.SetActive(false);
    }

    public void LoadScores()
    {
        scoresMenuUI.SetActive(true);
    }

    public void LoadSettings()
    {
        settingsMenuUI.SetActive(true);
    }

    public void LoadLevelBase()
    {
        SceneManager.LoadScene(level);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadDiedMenu()
    {
        diedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadNextLevel()
    {
        int levels = PlayerPrefsManager.getLevel();
        SceneManager.LoadScene("Level"+ levels);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
