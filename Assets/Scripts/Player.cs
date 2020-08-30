using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 5f;

    private float horizontalMove;
    private float verticalMove;

    public GameObject bloodEffect;
    public GameObject hurtSound;

    public Animator animator;

    [HideInInspector]
    public Animator hurtAnim;

    [HideInInspector]
    public HealthManager hm;

    [HideInInspector]
    public CameraShake camShake;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name)
                 && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }

    private void Start()
    {
        hm = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthManager>();
        camShake = GameObject.FindObjectOfType<Camera>().GetComponent<CameraShake>();
        hurtAnim = GameObject.FindGameObjectWithTag("EffectsPanel").GetComponent<Animator>();
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
        // Blood Effect
        Instantiate(bloodEffect, transform);
        Instantiate(hurtSound, transform);

        // Screen Shake
        camShake.shakeDuration = 0.3f;

        // Screen Flashing Red
        hurtAnim.SetTrigger("Hurt");

        hm.health -= amount;
    }

}
