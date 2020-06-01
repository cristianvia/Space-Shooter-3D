using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int crashDamage = 1;
    public bool damageOnDestroy = false;
    public GameObject explosionEffect;
    public float scoreIncrementator = 0;

    //public AudioClip explosionSound;
    //AudioSource audioExplosion;
    public GameObject explosionSoundSpace;
    public GameObject explosionSoundPlayer;

    public GameObject firstAidkit, ammunition;
    //public void Start()
    //{
    //    audioExplosion = GetComponent<AudioSource>();
    //}
    private void OnDestroy()
    {
        //Esto se ejecuta en el destructor
        if (damageOnDestroy)
        {
            //player -> applyDamage(crashDamage)
        }

    }
    //Funcion que se llama al ser Impactado por una bala
    public void kill()
    {
        //Creamos un numero aleatorio entre 0 y 10 y forzamos que sea integer 
        int r = (int)Random.Range(0, 10f);
        //Si el numero es 3, cramos un firstAidKit
        if (r == 3)
        {
            //Creamos el objeto
            GameObject g = Instantiate(firstAidkit) as GameObject;
            //Lo colocamos donde se encuentra el enemigo
            g.transform.position = transform.position;
            //Lo rotamos para que nos mire
            g.transform.rotation = new Quaternion(180, 0, 0, 0);
        }
        //Si el numero es 4, creamos un ammunition
        if (r == 4)
        {
            GameObject g = Instantiate(ammunition) as GameObject;
            g.transform.position = transform.position;
            g.transform.rotation = new Quaternion(180, 0, 0, 0);
        }

        PlayerMovement p = FindObjectOfType<PlayerMovement>();
        p.score += scoreIncrementator;
        Explode();
        Instantiate(explosionSoundPlayer);
        //Audio de explosion
        //audioExplosion.clip = explosionSound;
        //audioExplosion.Play();
        //Por ultimo destruimos el objeto
        Destroy(gameObject);
    }
    //Funcion que se llama al ser chocado contra player
    public void Crash()
    {
        Explode();
        Instantiate(explosionSoundSpace);
        //audioExplosion.clip = explosionSound;
        //audioExplosion.Play();
        Destroy(gameObject);


    }
    public void Explode()
    {
        //Show explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //Instantiate(explosionSoundSpace);
    }
}
