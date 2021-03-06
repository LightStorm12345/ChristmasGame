﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform trans;
    public Rigidbody rb;
    public float moveForce;
    public int jumpForce;
    public float SprintSpeed;

    public GameObject Camera;

    private bool allowJump = true;
    private Vector3 playerStartPos = new Vector3(296.7f, 217.2f, 493.264f);

    // Nathan helped with support and helped with challenges that never existed
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //wasd controls
        if (Input.GetKey("w") == true)
        {
            rb.AddForce(trans.forward * moveForce * Time.deltaTime);
        }
        if (Input.GetKey("s") == true) 
        {
            rb.AddForce(trans.forward * moveForce * -1 * Time.deltaTime);
        }
        if (Input.GetKey("a") == true)
        {
            rb.AddForce(trans.right * moveForce * -1 * Time.deltaTime);
        }
        if (Input.GetKey("d") == true)
        {
            rb.AddForce(trans.right * moveForce * Time.deltaTime);
        }
        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) == true)
        {
            moveForce = moveForce + SprintSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) == true)
        {
            moveForce = moveForce - SprintSpeed;
        }

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftControl) == true)
        {
            moveForce = moveForce + 1000;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) == true)
        {
            moveForce = moveForce - 1000;
        }

        //jumping
        if (Input.GetKeyDown("space") == true && allowJump == true)
        {
            rb.AddForce(0, jumpForce, 0);
            allowJump = false;
        }
        //Map camera's y rotation onto the player colider
        trans.eulerAngles = new Vector3(0, Camera.transform.eulerAngles.y, 0);

        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            trans.position = playerStartPos;
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
         if (collisionInfo.collider.tag == "Ground")
        {
            allowJump = true;
        }
    }
}
