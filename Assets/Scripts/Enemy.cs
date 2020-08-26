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

    [HideInInspector]
    public Player player;

    public float timeBetweenAttacks = 0.5f;

    [HideInInspector]
    public float attackTime;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        health = fullHealth;
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodEffect, transform);

        Debug.Log("Took Damage");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            // Play Sound

            // Animation
        }
    }
}
