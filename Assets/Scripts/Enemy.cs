using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int fullHealth;
    private int health;

    public GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        health = fullHealth;
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
