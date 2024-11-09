using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystem;

public class CharlieBrown : Peanuts
{   
    public AudioManager theAudio;
    public TextMeshProUGUI CdialogueText, Cresponse1Text, Cresponse2Text;
    public GameObject Cr1p;
    public GameObject Cr2p;
    //buttons to reset the buttons ('unclick' them)
    public Button r1;
    public Button r2;

    public Dialogue myDialogue; //static type myDialogue
    private CharlieDialogue omyDialogue;    //not used
    private string game = "Pong";

    private DialogueSound dialogueSound;

    void Start()
    {
        //create new dialogue bubble & send it the game object to attach
        myDialogue = new CharlieDialogue(Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);    //dynamic type CharlieDialogue
        //myDialogue.v_displayDialogue(0);    //subclass fn bound

        //myDialogue = new Dialogue();
        //myDialogue.v_displayDialogue(0); //superclass fn bound

        // Load the audio clip from the Resources folder
        AudioClip peanutsTeacherClip = Resources.Load<AudioClip>("Owen/Peanuts/peanuts_teacher");
        if (peanutsTeacherClip != null)
        {
            dialogueSound = new DialogueSound(
                "peanuts_teacher", 
                peanutsTeacherClip, 
                "CharlieBrown", 
                "Peanuts", 
                AudioManager.Instance.GetComponent<AudioSource>()
            );
        }
        else
        {
            Debug.LogError("peanuts_teacher audio clip not found.");
        }

        //reload state
        p_dialogueNum = PeanutsDB.CharlieDialogueNum;
        loadAffection(PeanutsDB.CharlieAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));

        //get to it
        onDialogue(p_dialogueNum);
    }
    
    void Update()
    {
        //continuosly make sure database is up to date
        PeanutsDB.CharlieAffectionPts = getAffectionPoints();
        PeanutsDB.CharlieDialogueNum = p_dialogueNum;
    }

    /*a response button being hit will trigger this. 
    * decides how to respond to response through updating affection, setting next dialogue, and possibly starting a minigame
    */
    //private void v_toNextDialogue()
    protected override void v_toNextDialogue()
    {
        //see what dialouge we are currently on
        int d = getDialogueNum();
        switch(d){
            case 0:
            //check response num and respond accordingly.
                if (p_responseNum == 1){
                    p_dialogueNum=1;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(20);
                }
                p_responseNum = 0;
                break;
            case 1:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(30);
                }
                p_responseNum = 0;
                break;
            case 2:
                //if r1, p_dialogueNum=3, else 4
                if (p_responseNum == 1){
                    p_dialogueNum = 4;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 3;
                    updateAffection(-5);
                }
                p_responseNum = 0;
                break;
            case 3: 
                //if r1, p_dialogueNum=5, else 6
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-10);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(45);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    updateAffection(30);
                    initiateMiniGame(game);
                    //how to wait here?
                    //yield return null; //doesn't work
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 5:
                //player stops talking to charlie...
                PeanutsDB.CharlieLocked = 1;
                Debug.Log("charlie locked");
                p_dialogueNum=7;
                break;
            case 6:
                if (p_responseNum == 1){
                    p_dialogueNum = 5;
                    updateAffection(-2);
                } else if (p_responseNum == 2){
                    //p_dialogueNum = 8;
                    updateAffection(15);
                    initiateMiniGame(game);
                    p_dialogueNum=-1;
                    //yield return null;
                }
                p_responseNum = 0;
                break;
            case 7:
                //stuck
                break;
            case 8:
                //post game
                //give user option to keep talking?
                break;
            case -1:
                p_responseNum = 8;
                break;
            default:
                Debug.Log("uh oh - no dialogue match");
                break;
        }
        onDialogue(p_dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    /* this function is either called from start or onDialogue.
    * It will tell the Dialogue class to display the dialogue
    * and will also check for edge cases (win/lose a game, get locked out, or win character's love)
    * Also calls audio
    */
    public void onDialogue(int d)
    {
        //if user was just in a game, send them to post game convo
        if (p_dialogueNum == -1 && MainPlayer.GetMiniGameStatus() != -1)
        {
            Debug.Log("after a game");
            updateAffection(30);
            p_dialogueNum=8;
            d=8;
            MainPlayer.SetMiniGameStatus(-1);   //reset game status
            Update();   //make sure DB gets updated
        }
        //if user has entered the end of dialogue
        else if (p_dialogueNum == 5)
        {
            PeanutsDB.CharlieLocked = 1;
            p_dialogueNum = 7;
            Debug.Log("Charlie is locked");
        }  

        if (getAffectionPoints() >= 100) //check if they won yet
        {
            UIElementHandler.UIGod.EndGame(true, "Charlie");
        }      

        //Actually display dialogue
        myDialogue.v_displayDialogue(d);

        // AUDIO 
        if (dialogueSound != null)
        {
            // Play the sound for 3 seconds
            AudioManager.Instance.PlayForDuration(dialogueSound, 2f);
        } else {
            Debug.Log(string.Format("No song found for funciton onDialogue"));
        }
    }
    
}
