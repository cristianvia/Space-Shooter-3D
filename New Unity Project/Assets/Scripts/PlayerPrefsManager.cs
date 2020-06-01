using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void initialize()
    {
        if(!PlayerPrefs.HasKey("com.P9M.SpaceRace.UserName"))
            PlayerPrefs.SetString("com.P9M.SpaceRace.UserName", "Player");
        if (!PlayerPrefs.HasKey("com.P9M.SpaceRace.Volume"))
            PlayerPrefs.SetFloat("com.P9M.SpaceRace.Volume", 1);
        if (!PlayerPrefs.HasKey("com.P9M.SpaceRace.Mute"))
            PlayerPrefs.SetInt("com.P9M.SpaceRace.Mute", 0);
        if (!PlayerPrefs.HasKey("com.P9M.SpaceRace.Level"))
            PlayerPrefs.SetInt("com.P9M.SpaceRace.Level", 1);
    }
    public static void setUserName(string name)
    {
        PlayerPrefs.SetString("com.P9M.SpaceRace.UserName", name);
    }
    public static string getUserName()
    {
        return PlayerPrefs.GetString("com.P9M.SpaceRace.UserName");
    }
    public static void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("com.P9M.SpaceRace.Volume", volume);
    }
    public static float getVolume()
    {
        return PlayerPrefs.GetFloat("com.P9M.SpaceRace.Volume");
    }
    public static void setMute(int mute)
    {
        PlayerPrefs.SetInt("com.P9M.SpaceRace.Mute", mute);
    }
    public static int getMute()
    {
        return PlayerPrefs.GetInt("com.P9M.SpaceRace.Mute");
    }
    public static void setLevel(int level)
    {
        PlayerPrefs.SetInt("com.P9M.SpaceRace.Level", level);
    }
    public static int getLevel()
    {
        return PlayerPrefs.GetInt("com.P9M.SpaceRace.Level");
    }
}
