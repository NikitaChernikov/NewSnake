using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{

    int speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
