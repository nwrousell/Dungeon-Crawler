using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int fullHealth;

    [HideInInspector]
    public int health;

    public float speed = 5f;

    public GameObject bloodEffect;
    public GameObject hitSound;

    [HideInInspector]
    public RoomManager rm;

    [HideInInspector]
    public Player player;

    public float timeBetweenAttacks = 0.5f;

    [HideInInspector]
    public float attackTime;

    public int damage;

    void Start()
    {
        health = fullHealth;
        player = GameObject.FindObjectOfType<Player>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodEffect, transform);
        Instantiate(hitSound, transform);

        if (health <= 0)
        {
            rm.EnemyKilled();
            Destroy(gameObject, 0.1f);
        }
        else
        {
            // Play Sound

            // Animation
        }
    }
}
