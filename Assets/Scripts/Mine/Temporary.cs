using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{

    public float lifeTime = 3;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
