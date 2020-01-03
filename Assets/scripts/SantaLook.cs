using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaLook : MonoBehaviour
{
    public Transform Player;
    public float power = 0.5f;

    void Update()
    {
        Vector3 point = new Vector3(-90, 0, Player.position.z);
        Vector3 currPos = new Vector3(-90, 0, transform.position.z);

        Quaternion TargetRotation = Quaternion.LookRotation(Player.position - currPos);

        float str = Mathf.Min(power * Time.deltaTime, 1);

        transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, str);
    }
}
