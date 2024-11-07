using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStock : MonoBehaviour
//PATTERN 2. 'dependent' functionality
{
    public BirdManager birdManager;
    public GameObject birdManagerObject;
    public SpriteRenderer sprite;

    private Snoopy theSnoop;

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

    public void Begin(Snoopy aSnoop){
        theSnoop = aSnoop;
        Debug.Log("attaching this");
        theSnoop.Attach(this);  //PATTERN 4. observers register themselves with the subject
        Debug.Log("attached");
    }

    public virtual void Refresh()
    {

    }

    protected Snoopy getSnoopy(){
        Debug.Log("in getSnoop");
        return theSnoop;
    }
}


