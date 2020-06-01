using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource myAudio;
    private void Start()
    {
        myAudio.volume = PlayerPrefsManager.getVolume();

        int mymute = PlayerPrefsManager.getMute();
        if (mymute == 0)
            myAudio.mute = false;
        else
            myAudio.mute = true;
    }
}
