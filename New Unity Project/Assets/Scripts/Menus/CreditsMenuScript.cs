using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuScript : MonoBehaviour
{
    public void SceneBack()
    {
        // If we want it to be a real "back" button we have to change the SceneManager
        SceneManager.LoadScene("MainMenu");
    }
}
