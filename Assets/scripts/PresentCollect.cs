using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PresentCollect : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject intText;
    public GameObject player;
    public GameObject intPlane;
    public GameObject SantaInteract;
    public GameObject EndScene;

    public GameObject Dialog;
    public Text dialogBox;
    public Text Speaker;
    public GameObject contText;
    public Text presCount;
    public GameObject presCountObj;

    [HideInInspector]
    public int presentCollected = 0;

    private float DistanceToDoor;
    private Vector3 playerStartPos = new Vector3(296.7f, 217.2f, 493.264f);

    public GameObject pres1;
    public GameObject pres2;
    public GameObject pres3;
    public GameObject pres4;
    public GameObject pres5;
    public GameObject pres6;


    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        Vector3 playerPos = player.transform.position;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);



        if (Physics.Raycast(ray, out hit))
        {

            float distPres1 = Vector3.Distance(player.transform.position, pres1.transform.position);
            float distPres2 = Vector3.Distance(player.transform.position, pres2.transform.position);
            float distPres3 = Vector3.Distance(player.transform.position, pres3.transform.position);
            float distPres4 = Vector3.Distance(player.transform.position, pres4.transform.position);
            float distPres5 = Vector3.Distance(player.transform.position, pres5.transform.position);
            float distPres6 = Vector3.Distance(player.transform.position, pres6.transform.position);

            float DistanceToDoor = Vector3.Distance(player.transform.position, intPlane.transform.position);
            float DistanceToSanta = Vector3.Distance(player.transform.position, SantaInteract.transform.position);

            if (hit.collider.name == pres1.name && distPres1 >= 0 && distPres1 <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pres1.SetActive(false);
                    presentCollected++;
                }
            }
            else if (hit.collider.name == pres2.name && distPres2 >= 0 && distPres2 <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pres2.SetActive(false);
                    presentCollected++;
                }
            }
            else if (hit.collider.name == pres3.name && distPres3 >= 0 && distPres3 <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pres3.SetActive(false);
                    presentCollected++;
                }
            }
            else if (hit.collider.name == pres4.name && distPres4 >= 0 && distPres4 <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pres4.SetActive(false);
                    presentCollected++;
                }
            }
            else if (hit.collider.name == pres5.name && distPres5 >= 0 && distPres5 <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pres5.SetActive(false);
                    presentCollected++;
                }
            }
            else if (hit.collider.name == pres6.name && distPres6 >= 0 && distPres6 <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pres6.SetActive(false);
                    presentCollected++;
                }
            }








            //Display "Press E" message when play is close to door and is looking at it

            else if (hit.collider.tag == "Door" && DistanceToDoor >= 0 && DistanceToDoor <= 4)
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

            else if (hit.collider.tag == "Santa" && DistanceToSanta >= 0 && DistanceToSanta <= 4)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) == true)
                {
                    if (presentCollected == 6)
                    {
                        StartCoroutine(DialogSequence2());
                    }
                    if (presentCollected != 6)
                    {
                        StartCoroutine(DialogSequence1());
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

        if (scene.name == "GameScene" && player.transform.position.y < 180)
        {
            player.transform.position = playerStartPos;
            print("player fell out of the map");
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        presCount.text = presentCollected + "/6 Presents\nCollected";
    }

    IEnumerator DialogSequence1()
    {
        contText.SetActive(false);
        player.GetComponent<movement>().enabled = false;
        Dialog.SetActive(true);
        Speaker.text = "Santa";
        dialogBox.text = "Ho Ho Ho, hello there. My sleigh has crashed and the presents have been thrown all around! \nCan you help me please?";

        yield return new WaitForSeconds(2);
        contText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        contText.SetActive(false);
        Speaker.text = "You";
        dialogBox.text = "Ok, I will try to help.";

        yield return new WaitForSeconds(1);
        contText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        contText.SetActive(false);
        Speaker.text = "Santa";
        dialogBox.text = "Oh jolly good! There are 6 presents, when you are done come back to me";

        yield return new WaitForSeconds(2);
        contText.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        player.GetComponent<movement>().enabled = true;
        Dialog.SetActive(false);
        presCountObj.SetActive(true);
    }
    IEnumerator DialogSequence2()
    {
        contText.SetActive(false);
        player.GetComponent<movement>().enabled = false;
        Dialog.SetActive(true);
        Speaker.text = "Santa";
        dialogBox.text = "Wonderful! You did it! Christmas is saved! I'll be sure to add you to the nice list permanently!";

        yield return new WaitForSeconds(2);
        contText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        contText.SetActive(false);
        Speaker.text = "You";
        dialogBox.text = "Thank you Santa!";

        yield return new WaitForSeconds(1);
        contText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        contText.SetActive(false);
        Speaker.text = "Santa";
        dialogBox.text = "I have to go now, goodbye! Merry Christmas!";

        yield return new WaitForSeconds(1);
        contText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        Dialog.SetActive(false);
        EndScene.SetActive(true);
        presCountObj.SetActive(false);
    }
}
