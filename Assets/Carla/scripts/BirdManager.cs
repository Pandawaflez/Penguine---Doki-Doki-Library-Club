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
        flywood.Begin(snoopy);
        spinwood.Begin(snoopy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
