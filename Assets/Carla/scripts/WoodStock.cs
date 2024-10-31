using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStock : MonoBehaviour
{
    public BirdManager birdManager;
    public GameObject birdManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("main");
        //set up birdManager reference object
        birdManagerObject = GameObject.FindWithTag("BirdController");
        
        if (birdManagerObject != null){
            birdManager = birdManagerObject.GetComponent<BirdManager>();
        }
        else {
            Debug.Log("uh oh! Bird Manager not found");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class FlowerWoodStock : WoodStock
{
    void Start()
    {
        Debug.Log("flower");
    }
}

public class WritingWoodStock : WoodStock
{
    void Start()
    {
        Debug.Log("write");
    }
}

