using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public List<GameObject> enemyList;
    public GameObject point1, point2;

    private GameObject enemyInScene; //To instantiate an object it is need to related with something
    public float targetTime = 5f;
    private float myTimer;
    private UserSceneManager sceneManager;
    private void Start()
    {
        myTimer = targetTime;
        sceneManager = FindObjectOfType<UserSceneManager>();
    }
    public void Update()
    {
        if (sceneManager.started) 
        {
            //Crea un enemigo al finalizar myTime
            myTimer -= Time.deltaTime;

            if (myTimer <= 0.0f)
            {
                SpawnAnEnemy();
                myTimer = targetTime;
            }
        }

    }

    void SpawnAnEnemy()
    {
        Vector3 p1, p2;
        p1 = point1.transform.position;
        p2 = point2.transform.position;
        Vector3 position = new Vector3(Random.Range(p1.x, p2.x), Random.Range(p1.y, p2.y), Random.Range(p1.z, p2.z));
        enemyInScene = GameObject.Instantiate(enemyList[Random.Range(0, enemyList.Count)], position, Quaternion.identity) as GameObject;
    }
}
