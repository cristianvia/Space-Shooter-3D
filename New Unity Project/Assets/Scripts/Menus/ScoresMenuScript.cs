using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class ScoresMenuScript : MonoBehaviour
{
    public TextMeshProUGUI scoreList;
    public TextMeshProUGUI scoreListAll;
    private string rootFolder;
    ScoresCollection scoresCollection;
    List<Score> sortedScores;
    public GameObject allScores;
    public GameObject scoresMenu;
    public GameObject pauseMenu;


    private void Start()
    {
#if UNITY_EDITOR
        rootFolder = Application.dataPath;
        //Si estamos en Android o iOS cogerá el path de persistentDataPath, que es una carpeta que crea unity en estos dispositivos con
        //los archivos que necesitará mas tarde como es el caso
#elif UNITY_ANDROID || UNITY_IOS
        rootFolder = Application.persistentDataPath;
#endif
        List<Score> scores = ScoresCollection.Load(Path.Combine(rootFolder, "scores.xml")).scores;
        sortedScores = scores.OrderByDescending(o => o.value).ToList();

        if (sortedScores[0] != null)
            scoreList.text = "1. " + sortedScores[0].value.ToString("0") + " " + sortedScores[0].name + "\n";
        if (sortedScores[1] != null)
            scoreList.text += "2. " + sortedScores[1].value.ToString("0") + " " + sortedScores[1].name + "\n";
        if (sortedScores[2] != null)
            scoreList.text += "3. " + sortedScores[2].value.ToString("0") + " " + sortedScores[2].name + "\n";
    }
    public void LoadShowAll()
    {
        int index = 1;
        allScores.SetActive(true);
        //SceneManager.LoadScene("TODO");
        if (sortedScores.Count != 0)
        {
            scoreListAll.text = "";
            foreach (Score s in sortedScores)
            {
                scoreListAll.text += index + ". " + s.value.ToString("0") + " " + s.name + "\n";
                index++;
            }
        }
            
    }
    public void SceneBackLevelBase()
    {
        if (!allScores.activeSelf)
        {
            scoresMenu.SetActive(false);
        }
        else
            allScores.SetActive(false);
    }
    public void SceneBack()
    {
        if (!allScores.activeSelf)
        {
            SceneManager.LoadScene("MainMenu");
        }else
            allScores.SetActive(false);
    }
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
}
