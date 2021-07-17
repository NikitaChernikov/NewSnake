using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThree : MonoBehaviour
{
    bool movingRight = true;
    Rigidbody2D rb;
    SpriteRenderer sr;

    int direction;

    bool falling = true;

    bool down = true;

    int sec;

    int counter = 0;

    float randX, randY;
    Vector2 whereToSpawn;

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    private GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(counter >= 6)
        {
            Destroy(this.gameObject);
        }

        if (!falling)
        {
            rb.velocity = new Vector2(0, 0);
            if (movingRight)
            {
                moveToSecondSide();
            }
            else if (!movingRight)
            {
                moveToFirstSide();
            }
        }
        else if (falling)
        {
            rb.velocity = new Vector2(0, 0);
            if (down)
            {
                FallDown();
            }
            else if (!down)
            {
                MoveUp();
            }
        }
    }

    void FallDown()
    {
        direction = -1;
        rb.velocity = new Vector2(rb.velocity.x, direction * moveSpeed * 5);
    }

    void MoveUp()
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
        }
        else if (collision.gameObject.tag == "LeftBorder")
        {
            movingRight = true;
        }

        if (collision.gameObject.tag == "ButtomBorder")
        {
            down = false;
            randX = gameObject.transform.position.x;
            randY = gameObject.transform.position.y;
            whereToSpawn = new Vector2(randX, randY);
            GameObject newFood = Instantiate(food, whereToSpawn, Quaternion.identity) as GameObject;
            counter += 1;
        }
        else if(collision.gameObject.tag == "UpBorder")
        {
            down = true;
            falling = false;
            StartCoroutine(Delay());
        }
    }

    

    IEnumerator Delay()
    {
        sec = Random.Range(2, 8);
        yield return new WaitForSeconds(sec);
        falling = true;
    }
}
