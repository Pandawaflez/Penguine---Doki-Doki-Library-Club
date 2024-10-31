using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string name{get; set;}
    public Sprite roomImage{get; set;}

    virtual public void loadRoom (){
        Debug.Log("Loading Room...");
    }

}
