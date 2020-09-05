using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{

    public float fullHealth = 6f;

    public float health;

    private Animator effectsPanelAnim;
    private Player player;

    public Image[] heartImages;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    [HideInInspector]
    public bool calledDeadStuff = false;

    public TextMeshProUGUI gameOverText;

    void Start()
    {
        health = fullHealth;
        effectsPanelAnim = GameObject.FindGameObjectWithTag("EffectsPanel").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        // If health is greater than fullHealth, fix it
        if(health > fullHealth)
        {
            health = fullHealth;
        }else if (health <= 0 && !calledDeadStuff)
        {
            calledDeadStuff = true;
            // Player is Dead
            player.canMove = false;
            effectsPanelAnim.SetBool("Dead", true);
            gameOverText.enabled = true;

            // Move Player Sideways
            player.transform.rotation = Quaternion.Euler(0,0,90);

            // Hide Weapon
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

            //Zoom in on Player
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 5;

            // Restart Game after 3 seconds
            Invoke("CallRestart", 3f);
        } 

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
    private void CallRestart()
    {
        gameObject.GetComponent<LoadManager>().Restart();
    }
}
