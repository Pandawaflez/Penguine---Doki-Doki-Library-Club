using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldManagement : MonoBehaviour
{
    //sdggsdlkdjg
    [SerializeField]
    private string currentRoom = "FrontDesk";

    [SerializeField]
    private Sprite frontDeskImage;
    /*static overworldCharacter overworldCharacters;
    static room rooms; */
    [SerializeField]
    private Image background;
    [SerializeField]
    private GameObject testPanel;

    public void loadRoom1 (){
        background.sprite = frontDeskImage;
    }

    public void openTestPanel(){
        testPanel.SetActive(true);
    }

}
