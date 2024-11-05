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

    public Dialogue myDialogue;
    private CharlieDialogue omyDialogue;    //not used
    private string game = "Pong";

    // AUDIO - ADDED BY OWEN 
    private DialogueSound dialogueSound;

    void Start()
    {
        //create new dialogue bubble & send it the game object to attach
        myDialogue = new CharlieDialogue(Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        //theAudio = new AudioManager();

        // AUDIO - ADDED BY OWEN:
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
        // END OF OWEN'S AUDIO CODE

        p_dialogueNum = PeanutsDB.CharlieDialogueNum;
        loadAffection(PeanutsDB.CharlieAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));
        onDialogue(p_dialogueNum);
    }
    
    void Update()
    {
        PeanutsDB.CharlieAffectionPts = getAffectionPoints();
        PeanutsDB.CharlieDialogueNum = p_dialogueNum;
    }

    /*
        //button one calls onclick
        public void hitResponse1()
        {
            p_responseNum = 1;
            Debug.Log("they hit it boss");
            //StartCoroutine(holdUp(10));
            //unselect button for next screen
            r1.Select();
            toNextDialogue();
        }

        //button 2 calls onclick
        public void hitResponse2()
        {
            p_responseNum = 2;
            r2.Select();
            toNextDialogue();
        }
        */

    /*
        this function is called when a button is hit
        decides what to do (update affection pts, next dialogue number and/or to initiate minigame) based off response
        calls onDialogue() at end
    */
    //private void toNextDialogue()
    protected override void toNextDialogue()
    {
        int d = getDialogueNum();
        switch(d){
            case 0:
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

    //calls myDialogue with the updated dialogue number, and triggers audio
    public void onDialogue(int d)
    {
        //if user was just in a game, send them to post game convo
        if (p_dialogueNum == -1 && MainPlayer.GetMiniGameStatus() != -1){
            updateAffection(30);
            p_dialogueNum=8;
            MainPlayer.SetMiniGameStatus(-1);   //reset game status
        }
        else if (p_dialogueNum == 5){
            PeanutsDB.CharlieLocked = 1;
            p_dialogueNum = 7;
            Debug.Log("Charlie is locked");
        }        

        //theAudio.loadSounds();
        myDialogue.v_displayDialogue(d);

        // AUDIO - ADDED BY OWEN
        if (dialogueSound != null)
        {
            // Play the sound for 3 seconds
            AudioManager.Instance.PlayForDuration(dialogueSound, 2f);
        } else {
            Debug.Log(string.Format("No song found for funciton onDialogue"));
        }
        // END OF OWEN CODE
    }
    
}
