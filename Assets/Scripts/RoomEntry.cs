using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{

    private bool used = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !used)
        {
            transform.parent.gameObject.GetComponent<RoomManager>().RoomEntered();
            used = true;
        }
    }

}
