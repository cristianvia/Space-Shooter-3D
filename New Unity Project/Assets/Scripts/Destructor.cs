﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger");
        Destroy(other.gameObject);
    }
}
