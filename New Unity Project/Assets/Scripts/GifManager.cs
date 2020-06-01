using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifManager : MonoBehaviour
{
    //var frames : Texture2D[]; var framesPerSecond = 10.0;
    public Texture2D[] frames;
    public float framesPerSecond = 10.0f;
    public RawImage myImage;
    int index = 0;
    float indexf = 0;
    int previousMilisecond = 0;
    int  miliseconds = 0;
    void Update() 
    {
        if (previousMilisecond != System.DateTime.Now.Millisecond)
            miliseconds += 1;
        index = (int) (((miliseconds * 60)/100) / framesPerSecond);

        //indexf += Time.deltaTime;// % frames.Length;
        //index = (int) ( indexf * framesPerSecond);
        //var index : int = Time.time * framesPerSecond;
        Debug.Log(index);
        if (index >= frames.Length)
            miliseconds = 0;

        myImage.texture = frames[index];
        index = index % frames.Length; 
        
    }
}
