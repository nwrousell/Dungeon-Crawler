using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public int damage;

    public float coolDown;
    private float canAttackTime;

    public Transform attackPos;
    public float attackRange;

    public LayerMask whatIsEnemies;

    private bool swinging = false;

    private void Update()
    {
        // Points sword towards cursor if not swinging
        if (!swinging)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45; // Subtract 45 to account for the angle of the sword sprite
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }

        /*if (Time.time >= canAttackTime && Input.GetKey(KeyCode.Space))
        {
            // attack

            Coroutine swing = StartCoroutine(Swing(180, 0.1f));

            canAttackTime = Time.time + coolDown;
        }
        */
    }

    IEnumerator Swing(int swingRange, float swingLength)
    {
        swinging = true;
        float endTime = Time.time + swingLength;

        // set sword back half of the Swing Angle
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (swingRange/2));

        float swingIncrement = -(swingRange / (swingLength / 0.01f));

        while (Time.time < endTime)
        {
            // Increment the sword forward in a swing


            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + swingIncrement);
            yield return new WaitForSeconds(0.01f);
        }
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }

        swinging = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

}
