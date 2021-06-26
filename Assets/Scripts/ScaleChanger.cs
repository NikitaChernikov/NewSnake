using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScaleChanger : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(DelayDown());
    }

    public void ScaleUp()
    {
        anim.SetTrigger("ScaleUp");
        StartCoroutine(DelayUp());
    }

    IEnumerator DelayUp()
    {
        yield return new WaitForSeconds(2);
        ScaleDown();
    }

    public void ScaleDown()
    {
        anim.SetTrigger("ScaleDown");
        StartCoroutine(DelayDown()); 
    }

    IEnumerator DelayDown()
    {
        yield return new WaitForSeconds(2);
        ScaleUp();
    }
}
