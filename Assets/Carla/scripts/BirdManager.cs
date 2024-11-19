using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BirdManager : MonoBehaviour
{
    public Snoopy snoopy;
    public WoodStock woodStock;

    public FlyWoodStock flywood;
    public SpinWoodStock spinwood;

    void Start()
    {
        //PATTERN: birdmanager is the client
        flywood.Begin(snoopy);
        spinwood.Begin(snoopy);
    }
}
