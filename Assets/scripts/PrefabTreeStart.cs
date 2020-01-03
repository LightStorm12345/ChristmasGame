using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTreeStart : MonoBehaviour
{
    private Vector3 rayDir = new Vector3(0, -90, 0);
    public float yInset;

    public GameObject noTreeZone;
    public GameObject pres1;
    public GameObject pres2;
    public GameObject pres3;
    public GameObject pres4;
    public GameObject pres5;
    public GameObject pres6;

    private void Start()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayDir, out hit))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (hit.distance + yInset), transform.position.z);
        }

        if (Vector3.Distance(transform.position, noTreeZone.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, pres1.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, pres2.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, pres3.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, pres4.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, pres5.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, pres6.transform.position) <= 30)
        {
            if (FindObjectOfType<TreeMaker>().debugTreeGen == true)
            {
                print("Tree was too close to No-Zone, deleted " + gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}
