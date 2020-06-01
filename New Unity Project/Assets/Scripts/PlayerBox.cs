using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    public Rigidbody rb;
    public float velocity = 2000f;
    private UserSceneManager sceneManager;
    
    private void Start()
    {
        sceneManager = FindObjectOfType<UserSceneManager>();
        PlayerPrefsManager playerPrefsManager = new PlayerPrefsManager();
        //playerPrefsManager.setUserName("MI USUARIO");
        //Debug.Log(playerPrefsManager.getUserName());
    }
    void Update()
    {
        if (sceneManager.started)
        {
            //rb.AddForce(new Vector3(0, 0, velocity * Time.deltaTime), ForceMode.Force);
            rb.velocity = new Vector3(0, 0, velocity);
        }
    }
}
