using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoobTestcript
{
    // A Test behaves as an ordinary method
    [Test]
    public void ScoobTestcriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ScoobTestcriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

public class ButtonOverloadTest //clicking buttons almost simultaneously
{
    public Button button1;
    public Button button2;


    private bool button1active = false;
    private bool button2active = false;
    

    [UnityTest]

    public IEnumerator StartButtonPress(){

        button1.onClick.AddListener(Button1Clicked);
        button2.onClick.AddListener(Button2Clicked);

        

        button1.onClick.Invoke();
        button2.onClick.Invoke();

        yield return null;

        

        Assert.IsTrue(button1active ^ button2active, "Only one button should register a click.");
        button1.onClick.RemoveListener(Button1Clicked);
        button2.onClick.RemoveListener(Button2Clicked);

        Debug.Log("Button stress test complete");
    }    

    private void Button1Clicked(){
        Debug.Log("Button 1 clicked");
        button1active = true;
    }
    
    private void Button2Clicked(){
        Debug.Log("Button 2 clicked");
        button2active = true;
    }
}

//stress