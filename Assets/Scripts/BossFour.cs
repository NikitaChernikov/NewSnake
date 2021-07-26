using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFour : MonoBehaviour
{

    static int health = 3;

    int counter = 0;

    static Animator anim;

    /// Phase one
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject invincibility;
    float randX;
    Vector2 whereToSpawn;
    ///

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent <Animator>();
        rb = GetComponent<Rigidbody2D>();
        FirstFase();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FirstFase()
    {
        if (health == 3)
        {
            if (counter <= 5)
            {
                StartCoroutine(DelayOne());
                anim.SetTrigger("Attack");
                randX = Random.Range(-2.6f, 2.6f);
                whereToSpawn = new Vector2(randX, 1f);
                GameObject newEnemy = Instantiate(enemy, whereToSpawn, Quaternion.identity) as GameObject;
            } else
            {
                whereToSpawn = new Vector2(0f, 1f);
                GameObject newEnemy = Instantiate(invincibility, whereToSpawn, Quaternion.identity) as GameObject;
                StartCoroutine(DelayOne());
            }
        }
        else
        {
            SecondFase();
        }
    }

    void SecondFase()
    {
        if (health == 2)
        {
            while (gameObject.transform.position.x != 5.9f)
            {
                int direction = 1;
                rb.velocity = new Vector2(rb.velocity.x, direction * 3);
            }
        }
        else
        {
            ThirdFase();
        }
    }

    void ThirdFase()
    {
        if (health == 1)
        {

        }
        else
        {

        }
    }

    IEnumerator DelayOne()
    {
        yield return new WaitForSeconds(5);
        
        counter += 1;
        FirstFase();
    }

    public static void GetHit()
    {
        health -= 1;
        anim.SetTrigger("GetHit");
        Debug.Log(health);
    }
}
