using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class AmandaMinAffectionBoundary
{
    // A Test behaves as an ordinary method
    [Test]
    public void AmandaMinAffectionBoundarySimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AmandaMinAffectionBoundaryWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

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

        //Test 2: Min Affection Points
        Debug.Log("Tesing minimum affection points");
        //subtract 10, 5 times
        for(int i = 0; i < 6; i++){
            affectionManager.changeAffectionPoints(-10);
            Debug.Log($"Affection points after subtracting: {affectionManager.GetAffectionPoints()}");
        }

    }

}
