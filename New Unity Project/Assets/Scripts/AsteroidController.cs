using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : Enemy
{
    public float speed = 50.0f;
    private float x, y, z;
    private Vector3 multiplyer;
    private void Start()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        z = Random.Range(-1f, 1f);
        multiplyer = new Vector3(x, y, z);
    }
    // Update is called once per frame
    void Update()
    {

        //transform.Rotate(Vector3.one * horizontalSpeed * Time.deltaTime); 
        transform.Rotate(multiplyer * speed * Time.deltaTime);
    }
}
