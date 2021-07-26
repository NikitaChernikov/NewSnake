﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSide : MonoBehaviour
{

    [SerializeField]
    public float distance = -3.11f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Cloud")
        {
            other.gameObject.transform.position = new Vector3(distance, other.gameObject.transform.position.y, -.5f);
        }
    }
}
