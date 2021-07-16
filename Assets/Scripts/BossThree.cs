using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThree : MonoBehaviour
{
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public int direction ;

    [SerializeField]
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
        direction = 1;
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
    void moveToFirstSide()
    {
        sr.flipX = true;
        movingRight = false;
        direction = -1;
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
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
