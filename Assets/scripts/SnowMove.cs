using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMove : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;

    void Update()
    {
        transform.position = playerPos.position + offset;
    }
}
