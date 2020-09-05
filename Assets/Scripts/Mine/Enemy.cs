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

    public int[] coinsToDrop;

    public GameObject coinTemplate;

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

            int coins = Random.Range(coinsToDrop[0], coinsToDrop[1]);
            for (int i = 0; i < coins; i++)
            {
                float xChange = Random.Range(-3, 3);
                float yChange = Random.Range(-3, 3);
                Vector3 position = new Vector3(transform.position.x + xChange, transform.position.y + yChange, 0);
                GameObject coin = coinTemplate;

                coin.transform.position = position;

                Instantiate(coin);

            }
            Destroy(gameObject, 0.1f);
        }
        else
        {
            // Play Sound

            // Animation
        }
    }
}
