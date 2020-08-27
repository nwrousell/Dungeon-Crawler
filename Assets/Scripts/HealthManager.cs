using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public float fullHealth = 6f;

    public float health;

    public Image[] heartImages;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    void Start()
    {
        health = fullHealth;
    }

    void Update()
    {
        // Loop through heart images and render them correctly to show current health
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < Mathf.Floor(health/2f))
            {
                // Full Heart There
                heartImages[i].sprite = fullHeart;
            }else if (i == Mathf.Floor(health/2f) && i < health / 2f)
            {
                // Half Heart
                heartImages[i].sprite = halfHeart;
            }
            else
            {
                // Empty Heart
                heartImages[i].sprite = emptyHeart;
            }
        }
    }
}
