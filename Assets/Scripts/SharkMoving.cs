﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMoving : MonoBehaviour
{

    Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 0.5f;

    Animator anim;

    [SerializeField]
    private GameObject food;
    float randX, randY;
    Vector2 whereToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isWalk", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter (Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("Destroy");
            SpawnFood();
        }
    }


    private void SpawnFood()
    {
        randX = transform.position.x;
        randY = transform.position.y;
        whereToSpawn = new Vector2(randX, randY);
        GameObject newFood = Instantiate(food, whereToSpawn, Quaternion.identity) as GameObject;
    }
}