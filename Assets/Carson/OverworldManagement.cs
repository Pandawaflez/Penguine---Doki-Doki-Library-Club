using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldManagement : MonoBehaviour
{
    //sdggsdlkdjg
    [SerializeField]
    private string currentRoomName = "FrontDesk";
    /*static overworldCharacter overworldCharacters;
    static room rooms; */
    [SerializeField]
    private Image background;
    [SerializeField]
    private GameObject testPanel;

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

    private Room[] rooms = new Room[]
    {
        new Room(), //0
        new Room(), //1
        new Room(), //2
        new Room(), //3
        new ComputerRoom(), //4
        new Room(), //5
        new Room()  //6
    };

    public void initializeRooms() {
        if ( init ){
            Debug.Log("Already Initialized");
        } else {
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
            init = true;
        }
    }

    //placeholder/test function:
    public void loadRoom1 (){
        currentRoom = 0;
        background.sprite = rooms[0].roomImage;
        rooms[0].loadRoom();
    }

    public void goLeft (){
        if ( currentRoom == 0 ){
            currentRoom = 6;
        } else {
            currentRoom--;
        }
        background.sprite = rooms[currentRoom].roomImage;
        currentRoomName = rooms[currentRoom].name;
        rooms[currentRoom].loadRoom();
    }

    public void goRight (){
        if ( currentRoom == 6 ){
            currentRoom = 0;
        } else {
            currentRoom++;
        }
        background.sprite = rooms[currentRoom].roomImage;
        currentRoomName = rooms[currentRoom].name;
        rooms[currentRoom].loadRoom();
    }

    //opens test panel: by setting it to active:
    public void openTestPanel(){
        Debug.Log("Opening Character Panel");
        testPanel.SetActive(true);
    }

    public void start(){
        /*frontDeskImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/FrontDesk");
        bathroomImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/bathroom");
        fictionImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/fictionSection");
        nonfictionImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/nonfiction");
        computerImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/computerLab");
        studyImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/StudyTables");
        Sprite classImage = Resources.Load<Sprite>("Carson/RoomBackgrounds/classroom");*/
        initializeRooms();
    }

}
