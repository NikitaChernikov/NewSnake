using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{

    public GameObject food;

    private void Start()
    {
        Destroy(food, 5f);
    }
}
