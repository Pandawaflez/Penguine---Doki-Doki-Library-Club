using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject overworldResources;
    private OverworldData overworldData = new OverworldData();

    public void initializeOverworldData() {
        overworldData.initializeOverworldData( overworldResources );
    }

    public void loadRoom( int currentRoom ){
        overworldData.getImage("background").sprite = overworldData.getCurrentRoom().roomImage;
        //disable characters:
        GameObject characterLeftButton = overworldData.getResource("characterLeftButton");
        characterLeftButton.SetActive(false);
        GameObject characterRightButton = overworldData.getResource("characterRightButton");
        characterRightButton.SetActive(false);
        overworldData.getResource("computer").SetActive(false);
        //enable characters if needed:
        if ( overworldData.getCharacterPlacement(currentRoom*2) != "Empty" ) {
            characterLeftButton.SetActive(true);
            setCharacterImage( "left" , overworldData.getImage("characterLeft") );
        }
        if ( overworldData.getCharacterPlacement((currentRoom*2)+1) != "Empty" ) {
            characterRightButton.SetActive(true);
            setCharacterImage( "right" , overworldData.getImage( "characterRight" ) );
        }
        overworldData.getCurrentRoom().loadRoom();
    }

    // player navigation, called when the player moves to the room to the left
    public void goLeft (){
        int currentRoom = RoomsDB.getCurrentRoom();
        if ( currentRoom == 0 ){
            currentRoom = 6; //loop around
        } else {
            currentRoom--;
        }
        RoomsDB.setCurrentRoom(currentRoom); //set current room in database
        loadRoom(currentRoom);
    }

    // player navigation, called when the player moves to the room to the right
    public void goRight (){
        int currentRoom = RoomsDB.getCurrentRoom();
        if ( currentRoom == 6 ){
            currentRoom = 0; //loop around
        } else {
            currentRoom++;
        }
        RoomsDB.setCurrentRoom(currentRoom); //set current room in database
        loadRoom(currentRoom);
    }
    
    //opens test panel: by setting it to active:
    public void openTestPanel(){
        Debug.Log("Opening Character Panel");
        GameObject testPanelObject = overworldData.getResource("testPanelObject");
        if(testPanelObject != null){
            testPanelObject.SetActive(true);
            Debug.Log("testPanelObject set to active.");
        } else {
            Debug.Log("testPanelObject is null.");
        }
    }
    
    public void Awake(){
        initializeOverworldData();
        loadRoom(RoomsDB.getCurrentRoom());
    }

    //sets the given ui image to the sprite corresponding with the given character name.
    private void setCharacterImage( string leftOrRight , Image characterImage ){
        string character;
        int currentRoom = RoomsDB.getCurrentRoom();
        if (leftOrRight == "left"){
            character = overworldData.getCharacterPlacement(currentRoom*2);
        } else {
            character = overworldData.getCharacterPlacement((currentRoom*2)+1);
        }
        Debug.Log("Changing image to character:" + character);
        characterImage.sprite = overworldData.getCharacterImage( character );
    }

    public void characterL () {
        Debug.Log("Talk to Character L");
        int currentRoom = RoomsDB.getCurrentRoom();
        overworldData.getTestPanel().talkTo(overworldData.getCharacterPlacement((currentRoom*2)));
    }

    public void characterR () {
        Debug.Log("Talk to Character R");
        int currentRoom = RoomsDB.getCurrentRoom();
        overworldData.getTestPanel().talkTo(overworldData.getCharacterPlacement((currentRoom*2)+1));
    }

}
