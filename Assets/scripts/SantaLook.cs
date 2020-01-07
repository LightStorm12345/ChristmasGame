using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaLook : MonoBehaviour
{
    public Transform Player;
    public float power = 0.5f;

    //void Update()
    //{
        //Vector3 point = new Vector3(Player.position.x, Player.position.y, Player.position.z);
        //Vector3 currPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //Quaternion TargetRotation = Quaternion.LookRotation(point - transform.position);

        //float str = Mathf.Min(power * Time.deltaTime, 1);

        //transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, str);
    //}

    private void Update()
    {
        transform.LookAt(Player);
    }
}
