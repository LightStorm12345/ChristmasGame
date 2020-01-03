using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMaker : MonoBehaviour
{
    public Transform treePrefab;
    public int numberOfTrees;


    public int treeSeed;

    public bool useConstantSeed;

    public bool usePresetSeed;

    public bool ShowPercent;
    [HideInInspector]
    public bool debugTreeGen = false;


    void Start()
    {
        if (usePresetSeed == false)
        {
            if (useConstantSeed == false && PlayerPrefs.GetInt("useNewSeed") == 0)
            {
                int beginSeed = Random.Range(100, 1000000);
                print("Using seed: " + beginSeed);
                debugTreeGen = true;
                PlayerPrefs.SetInt("treeSeed", beginSeed);
                Random.InitState(PlayerPrefs.GetInt("treeSeed"));
                PlayerPrefs.SetInt("useNewSeed", 1);
            }
            else if (PlayerPrefs.GetInt("useNewSeed") == 1)
            {
                print("Using Seed: " + PlayerPrefs.GetInt("treeSeed"));
                Random.InitState(PlayerPrefs.GetInt("treeSeed"));
            }
            else
            {
                Random.InitState(treeSeed);
            }
        }
        else
        {
            Random.InitState(treeSeed);
        }


        for (int i = 1; i < numberOfTrees + 1; i++)
        {
            Vector3 treePos = new Vector3(Random.Range(10, 1000), 500, Random.Range(10, 1000));
            Transform clone;
            clone = Instantiate(treePrefab, treePos, Quaternion.identity);
            clone.rotation = Quaternion.LookRotation(new Vector3(0, 90, 0));
            clone.name = "Tree #" + i;
            clone.SetParent(gameObject.transform);

            int percentGen = (i * 100) / numberOfTrees;
            if (ShowPercent == true) 
            { 
                print(percentGen);
            }
            
        }
    }
}
