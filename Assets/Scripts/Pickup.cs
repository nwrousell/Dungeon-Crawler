using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int orangeJuices = 0;
    public int apples = 0;
    public int health = 0;

    public GameObject pickupEffect;

    private PickupManager pm;
    private HealthManager hm;

    public GameObject pickUpSound;

    private GameObject dropShadow;

    private void Start()
    {
        pm = GameObject.FindGameObjectWithTag("GameController").GetComponent<PickupManager>();
        hm = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthManager>();

        // Un-parent drop shadow so it doesn't follow animation
        if (transform.GetChild(0) != null) {
            dropShadow = transform.GetChild(0).gameObject;
            dropShadow.transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pm.AddApple(apples);
            pm.AddOrangeJuice(orangeJuices);

            hm.health += health;

            Instantiate(pickupEffect, transform);

            Instantiate(pickUpSound, transform);

            Destroy(gameObject, 0.05f);
            Destroy(dropShadow);
        }
    }

}
