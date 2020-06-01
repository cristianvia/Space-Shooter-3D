using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public Slider slider;
    public Toggle toggle;
    public GameObject settingsMenu;
    public bool onSettingsScene = false;
    public AudioSource myAudio;
    
    private void Start()
    {
        Debug.Log("START");
        userName.text = PlayerPrefsManager.getUserName();
        slider.value = PlayerPrefsManager.getVolume();

        if (PlayerPrefsManager.getMute() == 0) 
            toggle.isOn = false;
        else
            toggle.isOn = true;
    }

    public void ChangeVolume()
    {
        PlayerPrefsManager.setVolume(slider.value);
        try
        {
            if (!onSettingsScene)
            {
                UserSceneManager userSceneManager = FindObjectOfType<UserSceneManager>();
                userSceneManager.SetOnMusic(slider.value, toggle.isOn);
            }
            else
            {
                myAudio.volume = slider.value;
            }
                
        }
        catch (Exception e)
        {

        }
        
    }
    public void ChangeMute()
    {
        if(toggle.isOn)
            PlayerPrefsManager.setMute(1);
        else
            PlayerPrefsManager.setMute(0);

        try
        {
            if (!onSettingsScene)
            {
                UserSceneManager userSceneManager = FindObjectOfType<UserSceneManager>();
                userSceneManager.SetOnMusic(slider.value, toggle.isOn);
            }
            else
            {
                myAudio.mute = toggle.isOn;
            }
            
        }
        catch (Exception e)
        {

        }
    }
    public void ChangeName()
    {
        if (userName.text.Equals("") || userName.text.Equals(" "))
        {
            userName.text = PlayerPrefsManager.getUserName();
        }
        else
        {
            PlayerPrefsManager.setUserName(userName.text);
        }
    }
    public void SceneBackLevelBase()
    {
        // If we want it to be a real "back" button we have to change the SceneManager
        settingsMenu.SetActive(false);
    }
    public void SceneBack()
    {
        // If we want it to be a real "back" button we have to change the SceneManager
        SceneManager.LoadScene("MainMenu");
    }
}
