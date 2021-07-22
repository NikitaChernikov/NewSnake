using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public GameObject LevelScript;

    private Level pass;

    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    public int winScore;
    float rot;
    int score;

    public GameObject winScreen;
    public GameObject LoseScreen;
    Animator anim;
    public SpriteRenderer sr;

    public bool isDead;
    public float StartTime;
    public float EndTime;
    public bool isWin;
    public bool invis = false;
    public bool invincibility = false;

    public bool isVibrate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        pass = LevelScript.GetComponent<Level>();

        isWin = false;
        isDead = false;
        anim.SetBool("isWalk", true);
    }

    // Update is called once per frame
    void Update()
    {

        

        if (!isWin && !isDead)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x < gameObject.transform.position.x)
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
            winScreen.SetActive(true);


            pass.Pass();
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            if (isVibrate)
            {
                Handheld.Vibrate();
            }
            FindObjectOfType<AudioManager>().Play("EatingSound");
            if (!invis && !invincibility) anim.SetTrigger("doTouch");
            Destroy(collision.gameObject);
            moveSpeed += 0.2f;
            score++;

            if (score >= winScore)
            {
                isWin = true;
                FindObjectOfType<AudioManager>().Play("WinSound");
            }
        }
        else if (collision.gameObject.tag == "Danger")
        {
            if (!invincibility)
            {
                FindObjectOfType<AudioManager>().Play("DeathSound");
                if (isVibrate)
                    Handheld.Vibrate();
                isDead = true;
                LoseScreen.SetActive(true);
            } else if (invincibility)
            {
                FindObjectOfType<AudioManager>().Play("Destroy");
                Destroy(collision.gameObject);
            }
        }

        else if (collision.gameObject.tag == "Invisible")
        {
            if (!invincibility)
            {
                FindObjectOfType<AudioManager>().Play("EatingSound");
                invis = true;
                Destroy(collision.gameObject);
                Dissapear();
                StartCoroutine(Delay());
            } else
            {
                Destroy(collision.gameObject);
            }
        }

        else if (collision.gameObject.tag == "Invincible")
        {
            if (!invincibility)
            {
                FindObjectOfType<AudioManager>().Play("Armor");
                invincibility = true;
                Destroy(collision.gameObject);
                Invincibility();
                StartCoroutine(StayInvincible());
            } else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Hitter")
        {
            FindObjectOfType<AudioManager>().Play("EatingSound");
            Destroy(collision.gameObject);
            moveSpeed += 0.2f;
            BossOne.GetHit();
        }
    }

    public void Invincibility()
    {
        anim.SetTrigger("Invincible");
    }

    IEnumerator StayInvincible()
    {
        yield return new WaitForSeconds(6);
        invincibility = false;
    }

    public void Dissapear()
    {
        anim.SetBool("isInvis", true);
    }

    public void Appear()
    {
        anim.SetBool("isInvis", false);
        invis = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Appear();
    }
}
