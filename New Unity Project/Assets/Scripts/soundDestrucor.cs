using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundDestrucor : MonoBehaviour
{

    public float timeToDestroy = 2f;

    // Update is called once per frame
    void Update()
    {
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
        timeToDestroy -= Time.deltaTime;
    }
}
