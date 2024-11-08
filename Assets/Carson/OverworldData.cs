using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldData
{
    // Game Object References:
    [SerializeField]
    private overworldDebugMenu debugPanel;
    [SerializeField]
    private GameObject computer;
    [SerializeField]
    private Image background;
    [SerializeField]
    private GameObject testPanel;
    // 
    [SerializeField]
    private string currentRoomName = "FrontDesk";
    //Character buttons:
    [SerializeField]
    private Image characterLeft;
    [SerializeField]
    private Image characterRight;
    [SerializeField]
    private GameObject characterLeftButton;
    [SerializeField]
    private GameObject characterRightButton;

    //room data:
    private static bool init = false;
    private static int currentRoom = 0;
    [SerializeField]
    private Sprite frontDeskImage;
    [SerializeField]
    private Sprite bathroomImage;
    [SerializeField]
    private Sprite fictionImage;
    [SerializeField]
    private Sprite nonfictionImage;
    [SerializeField]
    private Sprite computerImage;
    [SerializeField]
    private Sprite studyImage;
    [SerializeField]
    private Sprite classImage;

    //characterImages:
    [SerializeField]
    private Sprite charlieImage;
    [SerializeField]
    private Sprite lucyImage;
    [SerializeField]
    private Sprite schroederImage;
    [SerializeField]
    private Sprite snoopyImage;
    [SerializeField]
    private Sprite shaggyImage;
    [SerializeField]
    private Sprite fredImage;
    [SerializeField]
    private Sprite daphneImage;
    [SerializeField]
    private Sprite sonicImage;
    [SerializeField]
    private Sprite shadowImage;

    public Sprite getCharacterImage( string character ){
        switch ( character ){
            case "Charlie":
                return charlieImage;
                break;
            case "Lucy":
                return lucyImage;
                break;
            case "Schroeder":
                return schroederImage;
                break;
            case "Snoopy":
                return snoopyImage;
                break;
            case "Shaggy":
                return shaggyImage;
                break;
            case "Daphne":
                return daphneImage;
                break;
            case "Fred":
                return fredImage;
                break;
            case "Sonic":
                return sonicImage;
                break;
            case "Shadow":
                return shadowImage;
                break;
            default:
                return shadowImage;
                Debug.Log("Character " + character + " not found");
                break;
        }
    }

}
