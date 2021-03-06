﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject intText;
    public GameObject intPlane;
    public GameObject player;
    public GameObject LightToggle;
    public GameObject CeilLight;
    public GameObject BulbOff;
    public GameObject BulbOn;

    private float DistanceToDoor;
    private Vector3 playerStartPos = new Vector3(296.7f, 217.2f, 493.264f);

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            //Display "Press E" message when play is close to door and is looking at it
            float DistanceToDoor = Vector3.Distance(player.transform.position, intPlane.transform.position);
            float DistanceToLight = Vector3.Distance(player.transform.position, LightToggle.transform.position);

            if (hit.collider.tag == "Door" && DistanceToDoor >= 0 && DistanceToDoor <= 4)
            {
                intText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) == true)
                {

                    if (scene.name == "HouseInside")
                    {
                        SceneManager.LoadScene("GameScene");
                    }

                    if (scene.name == "GameScene")
                    {
                        SceneManager.LoadScene("HouseInside");
                    }
                }
            }

            else if (hit.collider.tag == "Light" && DistanceToLight >= 0 && DistanceToLight <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) == true)
                {
                    if (CeilLight.activeSelf == true)
                    {
                        CeilLight.SetActive(false);
                        BulbOff.SetActive(true);
                        BulbOn.SetActive(false);
                    }
                    else
                    {
                        CeilLight.SetActive(true);
                        BulbOff.SetActive(false);
                        BulbOn.SetActive(true);
                    }
                }
            }



            else 
            {
                intText.SetActive(false);
            }

        }
        else
        {
            intText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        if (player.transform.position.y < -10)
        {
            player.transform.position = playerStartPos;
            print("player fell out of the map");
        }

    }
}
