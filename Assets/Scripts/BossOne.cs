using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOne : MonoBehaviour
{

    static Animator anim;
    int move;
    static int health;


    void Start()
    {
        health = 4;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Boss");
        RandomMove();
    }

    private void Update()
    {
        if (health == 0)
        {
            anim.SetTrigger("IsDead");
            Destroy(this.gameObject, 2f);
        }
    }

    public void RandomMove()
    {
        move = Random.Range(1, 5);
        switch (move)
        {
            case 1:
                anim.SetTrigger("BossToTheRight");
                StartCoroutine(Delay());
                break;
            case 2:
                anim.SetTrigger("BossToTheLeft");
                StartCoroutine(Delay());
                break;
            case 3:
                anim.SetTrigger("BossUp");
                StartCoroutine(Delay());
                break;
            case 4:
                anim.SetTrigger("BossDown");
                StartCoroutine(Delay());
                break;
        }
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger("Boss");
        RandomMove();
    }

    public static void GetHit()
    {
        health -= 1;
        anim.SetTrigger("GetHit");
    }
}
