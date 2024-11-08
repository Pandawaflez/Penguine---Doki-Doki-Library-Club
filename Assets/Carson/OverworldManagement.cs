using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldManagement : MonoBehaviour
{
    private OverworldData overworldData;
    // Game Object References:
    [SerializeField]
    private overworldDebugMenu testPanel;
    [SerializeField]
    private GameObject testPanelObject;
    [SerializeField]
    private GameObject computer;
    [SerializeField]
    private Image background;
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

    public void initializeRooms() {
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
        computer.SetActive(false);
        currentRoom = RoomsDB.getCurrentRoom();
        init = true; //make sure we know that everything is good to go
    }

    //Load up the first room:
    public void loadRoom1 (){
        currentRoom = 0;
        background.sprite = rooms[0].roomImage;
        rooms[0].loadRoom();
        RoomsDB.setCurrentRoom(currentRoom);
    }

    public void loadRoom(){
        background.sprite = rooms[currentRoom].roomImage;
        currentRoomName = rooms[currentRoom].name;
        //disable characters:
        characterLeftButton.SetActive(false);
        characterRightButton.SetActive(false);
        computer.SetActive(false);
        //enable characters if needed:
        if ( characterPlacement[currentRoom*2] != "Empty" ) {
            characterLeftButton.SetActive(true);
            setCharacterImage( "left" , characterLeft );
        }
        if ( characterPlacement[(currentRoom*2)+1] != "Empty" ) {
            characterRightButton.SetActive(true);
            setCharacterImage( "right" , characterRight );
        }
        rooms[currentRoom].loadRoom();
        RoomsDB.setCurrentRoom(currentRoom); //set current room in database
    }

    // player navigation, called when the player moves to the room to the left
    public void goLeft (){
        if ( currentRoom == 0 ){
            currentRoom = 6; //loop around
        } else {
            currentRoom--;
        }
        loadRoom();
    }

    // player navigation, called when the player moves to the room to the right
    public void goRight (){
        if ( currentRoom == 6 ){
            currentRoom = 0; //loop around
        } else {
            currentRoom++;
        }
        loadRoom();
    }

    //opens test panel: by setting it to active:
    public void openTestPanel(){
        Debug.Log("Opening Character Panel");
        testPanelObject.SetActive(true);
    }

    public void Awake(){
        initializeRooms();
        placeCharacters();
        readCharacterPlacement();
        loadRoom();
    }

    private void placeCharacters(){
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
        //disable character images:
        characterLeftButton.SetActive(false);
        characterRightButton.SetActive(false);
        //enable character images if needed:
        if ( characterPlacement[currentRoom*2] != "Empty" ) {
            characterLeftButton.SetActive(true);
            setCharacterImage( "left" , characterLeft );
        }
        if ( characterPlacement[(currentRoom*2)+1] != "Empty" ) {
            characterRightButton.SetActive(true);
            setCharacterImage( "right" , characterRight );
        }
        rooms[currentRoom].loadRoom();
    }

    private void readCharacterPlacement () {
        for( int i = 0; i < numOfRooms*2; i++){
            Debug.Log("Character in slot " + i + ": " + characterPlacement[i] );
        }
    }

    //sets the given ui image to the sprite corresponding with the given character name.
    private void setCharacterImage( string leftOrRight , Image characterImage ){
        string character;
        if (leftOrRight == "left"){
            character = characterPlacement[(currentRoom*2)];
        } else {
            character = characterPlacement[(currentRoom*2)+1];
        }
        Debug.Log("Changing image to character:" + character);
        characterImage.sprite = overworldData.getCharacterImage( character );
    }

    public void characterL () {
        Debug.Log("Talk to Character L");
        testPanel.talkTo(characterPlacement[(currentRoom*2)]);
    }

    public void characterR () {
        Debug.Log("Talk to Character R");
        testPanel.talkTo(characterPlacement[(currentRoom*2)+1]);
    }

}
