using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LevelsMenuScript : MonoBehaviour
{
    // Int from 1 to 4. Represents the number of unlocked levels
    public int level = 0;
    // Represent wether each level is unlocked
    private bool unlockLevel2 = false;
    private bool unlockLevel3 = false;
    private bool unlockLevel4 = false;

    public GameObject container2, container3, container4;

    void Start()
    {
        level = PlayerPrefsManager.getLevel();
        if (level > 1)
        {
            unlockLevel2 = true;
            container2.SetActive(true);
            if (level > 2)
            {
                unlockLevel3 = true;
                container3.SetActive(true);
                if (level > 3)
                {
                    unlockLevel4 = true;
                    container4.SetActive(true);
                }
            }
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("LevelBase");
    }
    public void LoadLevel2()
    {
        if (unlockLevel2)
        {
            SceneManager.LoadScene("Level2");
        }
    }
    public void LoadLevel3()
    {
        if (unlockLevel3)
        {
            SceneManager.LoadScene("Level3");
        }
    }
    public void LoadLevel4()
    {
        if (unlockLevel4)
        {
            SceneManager.LoadScene("Level4");
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
