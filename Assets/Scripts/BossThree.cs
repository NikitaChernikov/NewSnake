using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThree : MonoBehaviour
{
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public int direction;

    public int fall;

    [SerializeField]
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        RandomMove();
    }

    // Update is called once per frame
    void RandomMove()
    {
        fall = Random.Range(0, 2);
        Debug.Log(fall);
        if (fall == 0)
        {
            MoveHorizontal();
        }
        else if (fall == 1)
        {
            MoveVertical();
        }
        StartCoroutine(DelayRandom());
    }

    IEnumerator DelayRandom()
    {
        yield return new WaitForSeconds(3);
        RandomMove();
    }

    public void MoveHorizontal()
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

    public void MoveVertical()
    {
        MoveDown();
    }

    public void MoveDown()
    {
        direction = -1;
        rb.velocity = new Vector2(rb.velocity.x, direction * moveSpeed * 3);
    }

    public void MoveUp()
    {
        direction = 1;
        rb.velocity = new Vector2(rb.velocity.x, direction * moveSpeed * 3);
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
            moveToFirstSide();
        }
        else if (collision.gameObject.tag == "LeftBorder")
        {
            movingRight = true;
            moveToSecondSide();
        }

        if (collision.gameObject.tag == "ButtomBorder")
        {
            MoveUp();
        }
    }
}
