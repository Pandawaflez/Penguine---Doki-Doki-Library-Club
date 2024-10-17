using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffinityStressTest : MonoBehaviour
{
   private AffectionManager affectionManager;
   public Button response1Button; //attach to button 1 in scene
    public Button response2Button; // attaach to button 2 in scene
    private ShadowDialogue shadowDialogue;

    void Start(){
        affectionManager = new AffectionManager();
        shadowDialogue = new ShadowDialogue(affectionManager);
        StartCoroutine(RapidInteractionTest());
    }
    private System.Collections.IEnumerator RapidInteractionTest(){
        Debug.Log("Starting stress test: ");
        
        //rapidly press response 1 20 times
        for(int i = 0; i < 20; i++){
            response1Button.onClick.Invoke();
            //wait until next frame
            yield return null;
        }

        //test response 2 20 times
        for(int i = 0; i < 20; i++){
            response2Button.onClick.Invoke();
            yield return null;
        }
        Debug.Log("Stress Test Completed");
    }
}
