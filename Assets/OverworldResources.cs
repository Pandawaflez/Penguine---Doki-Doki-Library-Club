using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldResources : MonoBehaviour
{
    // Game Object References:
    [SerializeField]
    private overworldDebugMenu testPanel;
    [SerializeField]
    private GameObject testPanelObject;
    [SerializeField]
    private GameObject computer;
    [SerializeField]
    private Image background;
    //Character buttons:
    [SerializeField]
    private Image characterLeft;
    [SerializeField]
    private Image characterRight;
    [SerializeField]
    private GameObject characterLeftButton;
    [SerializeField]
    private GameObject characterRightButton;
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

    public overworldDebugMenu getTestPanel () {
        return testPanel;
    }

    public GameObject getResource( string resource ){
        switch ( resource ){
            case "computer":
                return computer;
                break;
            case "testPanelObject":
                return testPanelObject;
                break;
            case "characterLeftButton":
                return characterLeftButton;
                break;
            case "characterRightButton":
                return characterRightButton;
                break;
            default:
                return computer;
                Debug.Log("GameObject " + resource + " not found");
                break;
        }
    }

    public Image getImage( string resource ){
        switch ( resource ){
            case "background":
                return background;
                break;
            case "characterLeft":
                return characterLeft;
                break;
            case "characterRight":
                return characterRight;
                break;
            default:
                Debug.Log("Image " + resource + " not found");
                return characterLeft;
                break;
        }
    }
    
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

    public Sprite getRoomImage( string room ){
        switch ( room ){
           case "FrontDesk":
                return frontDeskImage;
                break;
            case "Bathroom":
                return bathroomImage;
                break;
            case "FictionSection":
                return fictionImage;
                break;
            case "NonfictionSection":
                return nonfictionImage;
                break;
            case "ComputerLab":
                return computerImage;
                break;
            case "StudyRoom":
                return studyImage;
                break;
            case "Classroom":
                return classImage;
                break;
            default:
                return frontDeskImage;
                Debug.Log("Room " + room + " not found");
                break;
        }
    }

}
