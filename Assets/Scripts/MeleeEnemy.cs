using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    public float stopDistance = 1f;

    public float attackSpeed = 10f;

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
        Vector2 originalPos = transform.position;
        Vector2 targetPos = player.transform.position;

        float percent = 0;
        bool doneDamage = false;

        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPos, targetPos, formula);
            if(percent >= 0.5 && !doneDamage)
            {
                player.GetComponent<Player>().TakeDamage(damage);
                doneDamage = true;
            }

            yield return null;
        }
        
    }

}