using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public BoxCollider2D spawnBounds;

    public GameObject[] toSpawn;
    public int[] amounts;

    private bool dissolve = false;
    private float entranceFade = 0f;

    private int enemiesDead = 0;

    public SpriteRenderer[] entrances;

    private void Spawn(int amount, GameObject entity)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 position = new Vector2(Random.Range(spawnBounds.bounds.min.x, spawnBounds.bounds.max.x), Random.Range(spawnBounds.bounds.min.y, spawnBounds.bounds.max.y));
            GameObject toSpawn = entity;
            toSpawn.transform.position = position;
            toSpawn.transform.rotation = Quaternion.Euler(0, 0, 0);
            toSpawn.GetComponent<Enemy>().rm = this;
            Instantiate(toSpawn);
        }
    }

    private void Update()
    {
        if (dissolve)
        {
            if(entranceFade < 1f)
            {
                entranceFade += Time.deltaTime;
                for (int i = 0; i < entrances.Length; i++) // Loop through all entrances
                {
                    entrances[i].material.SetFloat("_Noise", entranceFade);
                }
            }
            else
            {
                dissolve = false;
                UnlockRoom();
            }  
        }
    }

    public void EnemyKilled()
    {
        enemiesDead++;
        int total = 0;
        for (int i = 0;i < amounts.Length;i++)
        {
            total += amounts[i];
        }
        if(enemiesDead >= total)
        {
            // All Enemies killed
            dissolve = true;
        }

    }

    public void RoomEntered()
    {
        for (int i = 0; i < amounts.Length; i++)
        {
            Spawn(amounts[i], toSpawn[i]);
            Invoke("LockRoom", 0.2f);
        }
    }

    private void LockRoom()
    {
        transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        for (int i = 0; i < entrances.Length; i++)
        {
            entrances[i].material.SetFloat("_Noise", 0);
        }
    }
    private void UnlockRoom()
    {
        transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
