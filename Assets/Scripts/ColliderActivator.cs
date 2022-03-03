using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActivator : MonoBehaviour
{

    public Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = FindObjectOfType<Collider2D>();
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        this.collider.enabled = true;
    }
}
