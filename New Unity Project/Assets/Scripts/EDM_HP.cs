using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EDM_HP : MonoBehaviour
{
    public Slider slider;
    public float hp = 100.0f;
    public float damage = 5f;
    UserSceneManager mySceneManager;
    public PlayerMovement playerMovement;
    public Light light;
    public Color32 primaryColor, damageColor;
    bool hit= false;
    public float damageTimeIndicator = 0.1f;
    float damageTimePrivate = 0f;

    public GameObject explosionEffect;
    public GameObject explosionSoundSpace;
    //public GameObject explosionSoundPlayer;
    private void Start()
    {
        mySceneManager = FindObjectOfType<UserSceneManager>();
        mySceneManager.finalTime = 100000000000000;
        primaryColor = light.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("PlayerBullet"))
        {
            hp -= damage;
            playerMovement.score += 5;
            hit = true;
        }
    }
    private void Update()
    {
        slider.value = hp;

        if (hp <= 0)
        {
            mySceneManager.finalTime = 6;
            playerMovement.score += 200;
            Explode();
            Instantiate(explosionSoundSpace);
            slider.fillRect.localScale = new Vector3(0, 0, 0);
            gameObject.SetActive(false);
        }
        
        if (hit)
        {
            light.color = damageColor;
            damageTimePrivate += Time.deltaTime;
            if(damageTimeIndicator <= damageTimePrivate)
            {
                light.color = primaryColor;
                hit = false;
                damageTimePrivate = 0;
            }
        }
    }
    public void Explode()
    {
        //Show explosion effect
        GameObject _explotion = Instantiate(explosionEffect, transform.position, transform.rotation);
        _explotion.transform.localScale = new Vector3(100, 100, 100);
    }

}
