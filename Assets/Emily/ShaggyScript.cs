using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class ShaggyScript : Scooby
{
    //buttons for dialogue
    public Button ShagR1;
    public Button ShagR2;

    public int responseNum = 0;

    //selection of dialogues
    public void hitShagResponse1()
    {
        responseNum = 1;
        Debug.Log("Response 1 chosen");
        ShagR1.Select();
    }

    public void hitShagResponse2()
    {
        responseNum = 2;
        Debug.Log("Response 2 chosen");
        ShagR2.Select();
    }

    private ShagDialogue mvpShagDialogue;

    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    public GameObject Shag1p;
    public GameObject Shag2p;

    

    void Update() { }

}
