﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 5f;

    private float horizontalMove;
    private float verticalMove;

    public Animator animator;

    [HideInInspector]
    public HealthManager hm;

    private void Start()
    {
        hm = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthManager>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (horizontalMove != 0 || verticalMove != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(horizontalMove * speed * Time.fixedDeltaTime, verticalMove * speed * Time.fixedDeltaTime));
    }
    public void TakeDamage(int amount)
    {
        hm.health -= amount;
        Debug.Log("Health Lost.");
    }

}
