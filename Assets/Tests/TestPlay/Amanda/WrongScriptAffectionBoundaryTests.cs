/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionBoundaryTests : MonoBehaviour
{
    private AffectionManager affectionManager;
    void Start()
    {
        affectionManager = new AffectionManager();

        //Test 1: Max Affection Points
        Debug.Log("Testing maximum affection points");
        //add affection points up to 100.
        for(int i = 0; i < 6; i++){
            affectionManager.changeAffectionPoints(20);
            Debug.Log($"Affection points after addding: {affectionManager.GetAffectionPoints()}");
        }

        //reset affection points for min test
        affectionManager.changeAffectionPoints(-affectionManager.GetAffectionPoints());

        //Test 2: Min Affection Points
        Debug.Log("Tesing minimum affection points");
        //subtract 10, 5 times
        for(int i = 0; i < 6; i++){
            affectionManager.changeAffectionPoints(-10);
            Debug.Log($"Affection points after subtracting: {affectionManager.GetAffectionPoints()}");
        }

    }

}

*/