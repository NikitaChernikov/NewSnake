using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveHorizontal : MonoBehaviour
{

    
    GameObject firstSide, secondSide;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField]
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //firstSide = GameObject.Find("FirstSide").GetComponent<Transform>();
        //secondSide = GameObject.Find("SecondSide").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.x > secondSide.transform.position.x)
        {
            movingRight = false;
        }
        if (transform.position.x < firstSide.transform.position.x)
        {
            movingRight = true;
        }*/

        if (movingRight)
        {
            moveToSecondSide();
        }
        else
        {
            moveToFirstSide();
        }
    }


    void moveToSecondSide()
    {
        sr.flipX = false;
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }
    void moveToFirstSide()
    {
        sr.flipX = true;
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightBorder")
        {
            movingRight = false;
        }
        else if (collision.gameObject.tag == "LeftBorder")
        {
            movingRight = true;
        }
    }
}
