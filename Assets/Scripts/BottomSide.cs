using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSide : MonoBehaviour
{

    [SerializeField]
    public float distance = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, distance, -.5f);
        }
    }
}
