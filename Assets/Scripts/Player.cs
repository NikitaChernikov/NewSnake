using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    public int winScore;
    float rot;
    int score;
    public GameObject winText;
    Animator anim;
    SpriteRenderer sr;

    public bool isDead;
    public float StartTime;
    public float EndTime;
    public bool isWin;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        isDead = false;
        anim.SetBool("isWalk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWin)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x < 0)
                {
                    sr.flipX = true;
                    rot = rotateAmount;
                }
                else
                {
                    sr.flipX = false;
                    rot = -rotateAmount;
                }

                transform.Rotate(0, 0, rot);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDead && !isWin)
        {
            rb.velocity = transform.up * moveSpeed;
        }
        else if (isDead)
        {
            anim.SetBool("isDead", true);
            rb.velocity = transform.up * 0;
            StartTime += 0.1f * Time.deltaTime;

            if(StartTime >= EndTime)
            {
                gameObject.SetActive(false);
            }
        }
        else if (isWin)
        {
            rb.velocity = transform.up * 0;
            winText.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Handheld.Vibrate();
            anim.SetTrigger("doTouch");
            Destroy(collision.gameObject);
            moveSpeed += 0.5f;
            score++;

            if(score >= winScore)
            {
                isWin = true;
                
            }
        }
        else if (collision.gameObject.tag == "Danger")
        {
            Handheld.Vibrate();
            isDead = true;
            //SceneManager.LoadScene("Level 1");
        }
    }
}
