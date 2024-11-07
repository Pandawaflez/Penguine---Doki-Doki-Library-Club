using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//test to see how Unity handles many creations of the Overlay with 6 characters
public class Patrick_OverlayCreationStressTest
{
    public Sprite[] characterImages;
    private string[] _characterNames = { "Charlie", "Lucy", "Snoopy", "Schroeder", "Sonic", "Shadow", };
    private GameObject panel;

    private UIOverlay _UIOverlay;

    [OneTimeSetUp]
    public void OneTimeSetUp() 
    {
        panel = new GameObject("TestPanel");
        characterImages = new Sprite[6];
    }

    //stress test
    [UnityTest]
    public IEnumerator CreateNewOverlaysStress()
    {
        for(int i = 0; i < 10000; i ++)
        {
            _UIOverlay = new UIOverlay(panel, characterImages, _characterNames);    //expected to break from making new instances of the overlay
        }

        yield return null;
    }

}