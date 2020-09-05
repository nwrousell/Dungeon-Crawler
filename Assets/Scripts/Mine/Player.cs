using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 5f;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private bool dashing = false;
    private float canDash;
    public float dashCoolDown = 1.5f;

    private float horizontalMove;
    private float verticalMove;

    public GameObject bloodEffect;
    public GameObject hurtSound;
    public GameObject dashParticleEffect;
    private GameObject currentDashEffect;
    public GameObject dashSound;
    public GameObject coinSound;

    private Vector2 dashMovement;

    public Animator animator;

    private Animator hurtAnim;

    private HealthManager hm;
    private PickupManager pm;

    [HideInInspector]
    public bool canMove = true;

    private CameraShake camShake;

    /*private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name)
                 && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }*/

    private void Start()
    {
        hm = GameObject.FindGameObjectWithTag("GameController").GetComponent<HealthManager>();
        pm = GameObject.FindGameObjectWithTag("GameController").GetComponent<PickupManager>();
        camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        hurtAnim = GameObject.FindGameObjectWithTag("EffectsPanel").GetComponent<Animator>();

        dashTime = startDashTime;
    }

    private void Update()
    {
        if (canMove)
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

            if (Input.GetKey(KeyCode.LeftShift) && Time.time >= canDash && (horizontalMove != 0 || verticalMove != 0))
            {
                dashing = true;
                dashTime = startDashTime;
                canDash = Time.time + dashCoolDown;
                currentDashEffect = Instantiate(dashParticleEffect, transform);
                currentDashEffect.transform.parent = null;
                dashMovement = new Vector2(horizontalMove, verticalMove);
                Instantiate(dashSound, transform);
            }
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate()
    {
        if (!dashing)
        {
            rb.MovePosition(rb.position + new Vector2(horizontalMove * speed * Time.fixedDeltaTime, verticalMove * speed * Time.fixedDeltaTime));
        }
        else
            {
                if (dashTime > 0)
                {
                    dashTime -= Time.deltaTime;
                    rb.velocity = new Vector2(dashMovement.x * dashSpeed * Time.fixedDeltaTime, dashMovement.y * dashSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    dashing = false;
                    rb.velocity = Vector2.zero;
                }
            }
    }
    public void TakeDamage(int amount)
    {
        // Blood Effect
        Instantiate(bloodEffect, transform);
        Instantiate(hurtSound, transform);

        Debug.Log("camshake: " + camShake);
        Debug.Log("hurtanim: " + hurtAnim);

        // Screen Shake
        camShake.shakeDuration = 0.3f;

        // Screen Flashing Red
        hurtAnim.SetTrigger("Hurt");

        hm.health -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            pm.AddCoins(1);
            Destroy(collision.gameObject);
            Instantiate(coinSound);
        }
    }

}

