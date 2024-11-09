using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldData
{
    // Game Object References:
    private overworldDebugMenu testPanel;
    private GameObject testPanelObject;
    private GameObject computer;
    private Image background;
    //Character buttons:
    private Image characterLeft;
    private Image characterRight;
    private GameObject characterLeftButton;
    private GameObject characterRightButton;
    //room data:
    private static bool init = false;
    private static int currentRoom = 0;
    private Sprite frontDeskImage;
    private Sprite bathroomImage;
    private Sprite fictionImage;
    private Sprite nonfictionImage;
    private Sprite computerImage;
    private Sprite studyImage;
    private Sprite classImage;
    //characterImages:
    private Sprite charlieImage;
    private Sprite lucyImage;
    private Sprite schroederImage;
    private Sprite snoopyImage;
    private Sprite shaggyImage;
    private Sprite fredImage;
    private Sprite daphneImage;
    private Sprite sonicImage;
    private Sprite shadowImage;

    private const int numOfRooms = 7;
    private Room[] rooms = new Room[]
    {
        new Room(), //0 - Front Desk
        new Room(), //1 - Bathroom
        new Room(), //2 - Fiction Section
        new Room(), //3 - Nonfiction Section
        new ComputerRoom(), //4 - Computer Lab
        new Room(), //5 - Study Room
        new Room()  //6 - Classroom
    };
    private const int numOfCharacters = 9;
    private string[] characterArray = {
        "Charlie", //0
        "Lucy", //1
        "Schroeder", //2
        "Snoopy", //3
        "Shaggy", //4
        "Fred", //5
        "Daphne", //6
        "Sonic", //7
        "Shadow" //8
    };
    private string[] characterPlacement = new string[numOfRooms*2];

    public Room getCurrentRoom(){
        return rooms[RoomsDB.getCurrentRoom()];
    }

    public string getCharacterPlacement( int x ){
        return characterPlacement[x];
    }

    public void initializeOverworldData( GameObject overworldResourcesObject ){
        //GameObject overworldResourcesObject = GameObject.FindWithTag("OverworldResources");
        OverworldResources overworldResources = overworldResourcesObject.GetComponent<OverworldResources>();
        if ( overworldResources == null ){
            Debug.Log("No Resources Found.  Sorry");
        } else {
            charlieImage = overworldResources.getCharacterImage("Charlie");
            lucyImage = overworldResources.getCharacterImage("Lucy");
            schroederImage = overworldResources.getCharacterImage("Schroeder");
            snoopyImage = overworldResources.getCharacterImage("Snoopy");
            fredImage = overworldResources.getCharacterImage("Fred");
            daphneImage = overworldResources.getCharacterImage("Daphne");
            shaggyImage = overworldResources.getCharacterImage("Shaggy");
            sonicImage = overworldResources.getCharacterImage("Sonic");
            shadowImage = overworldResources.getCharacterImage("Shadow");
            frontDeskImage = overworldResources.getRoomImage("frontDeskImage");
            bathroomImage = overworldResources.getRoomImage("bathroomImage");
            fictionImage = overworldResources.getRoomImage("fictionImage");
            nonfictionImage = overworldResources.getRoomImage("nonfictionImage");
            computerImage = overworldResources.getRoomImage("computerImage");
            studyImage = overworldResources.getRoomImage("studyImage");
            classImage = overworldResources.getRoomImage("classImage");
            // Game Object References:
            testPanel = overworldResources.getTestPanel();
            testPanelObject = overworldResources.getResource("testPanelObject");
            computer = overworldResources.getResource("computer");
            background = overworldResources.getImage("background");;
            characterLeft = overworldResources.getImage("characterLeft");
            characterRight = overworldResources.getImage("characterRight");
            characterLeftButton = overworldResources.getResource("characterLeftButton");
            characterRightButton = overworldResources.getResource("characterRightButton");
            //fill rooms with data:
            rooms[0].name = "FrontDesk";
            rooms[1].name = "Bathroom";
            rooms[2].name = "FictionSection";
            rooms[3].name = "NonfictionSection";
            rooms[4].name = "ComputerLab";
            rooms[5].name = "StudyRoom";
            rooms[6].name = "Classroom"; 
            rooms[0].roomImage = frontDeskImage;
            rooms[1].roomImage = bathroomImage;
            rooms[2].roomImage = fictionImage;
            rooms[3].roomImage = nonfictionImage;
            rooms[4].roomImage = computerImage;
            rooms[5].roomImage = studyImage;
            rooms[6].roomImage = classImage; 
            rooms[4].setComputer(computer);
            currentRoom = RoomsDB.getCurrentRoom();
            init = true; //make sure we know that everything is good to go
            //place characters:
            int j = 0;
            for ( int i = 0; i < numOfRooms*2; i++ ){
                characterPlacement[i] = "Empty";
            }
            for ( int i = 0; i < numOfCharacters; i++ ){
                int temp = Random.Range(0, (numOfRooms*2)-1);
                while ( characterPlacement[temp] != "Empty" ){
                    temp = Random.Range(0, (numOfRooms*2)-1);
                }
                characterPlacement[temp] = characterArray[j];
                j++;
            }
        }
    }

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
    /*
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
                Debug.Log("Room " + room + " not found");
                return frontDeskImage;
                break;
        }
    }*/

}
