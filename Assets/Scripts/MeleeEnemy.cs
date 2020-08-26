using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    public float stopDistance = 1f;

    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= stopDistance)
        {
            // Can Attack
            if(Time.time >= attackTime)
            {
                // Reset Attack Time
                attackTime = Time.time + timeBetweenAttacks;

                // Attack
                Coroutine attack = StartCoroutine(Attack());
            }
        }
        else
        {
            // Move Towards Player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        
    }

    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);
        yield return null;
    }

}