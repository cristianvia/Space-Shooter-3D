using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Enemy
{
    public PlayerMovement player;
    public Transform playerTransform;
    public float lerpVelocity;
    public Vector3 direction;

    public GameObject bulletPrefab;
    public float bulletSpeed = 50.0f;

    public GameObject firePoint;
    public float targetTime = 0.5f;
    private float myTimer;
    public bool canShoot = false;
    public bool randomTimeToShoot = false;
    public bool playerReached = false;
    private float yScale;

    //public int xCorrector, yCorrector, zCorrector;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        playerTransform = player.GetComponent<Transform>();
        myTimer = targetTime;
        yScale = transform.localScale.y;
        if (randomTimeToShoot)
            targetTime = Random.Range(2,7);
    }
    private void Update()
    {
        if (!playerReached)
        {
            //Dirigirse hacia
            direction = transform.position - playerTransform.position;
            direction.Normalize();
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z), lerpVelocity);

            //https://www.youtube.com/watch?v=7-8nE9_FwWs TUTORIAL ROTAR DIRECCTION

            Vector3 difference = playerTransform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;

            Vector3 r = new Vector3(0.0f, rotationY, rotationZ);
            transform.rotation = Quaternion.Euler(r);

            //check if the plalyer it's on my left to fix the bug that makes this prefab to turn down
            if (playerTransform.position.x < transform.position.x)
                transform.localScale = new Vector3(transform.localScale.x, -yScale, transform.localScale.z);
            else
                transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);

            //para disparar
            myTimer -= Time.deltaTime;

            if (myTimer <= 0.0f && canShoot)
            {
                fireBullet(direction, r);
                myTimer = targetTime;
            }
            if (playerTransform.position.z >= transform.position.z)
                playerReached = true;
        }
    }
    void fireBullet(Vector3 direction, Vector3 _rotation)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = firePoint.transform.position; // mirar si poner en otro punto 
        b.transform.rotation = Quaternion.Euler(_rotation.x -90, _rotation.y, _rotation.z);
        b.GetComponent<Rigidbody>().velocity = direction * (-bulletSpeed);

    }
}
