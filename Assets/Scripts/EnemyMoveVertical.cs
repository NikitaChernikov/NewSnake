using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveVertical : MonoBehaviour
{


    GameObject firstSide, secondSide;
    Vector3 localScale;
    bool movingUp = true;
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

        if (movingUp)
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
        movingUp = true;
        localScale.y = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(rb.velocity.x, localScale.y * moveSpeed);
    }
    void moveToFirstSide()
    {
        movingUp = false;
        localScale.y = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(rb.velocity.x, localScale.y * moveSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UpBorder")
        {
            movingUp = false;
        }
        else if (collision.gameObject.tag == "ButtomBorder")
        {
            movingUp = true;
        }
    }
}
