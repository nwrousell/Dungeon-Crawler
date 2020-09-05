using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void Update()
    {
        transform.position = playerTransform.position + offset;
    }

}
