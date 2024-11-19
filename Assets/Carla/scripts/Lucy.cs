using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Lucy : Peanuts
{
    //the following need to be public so we can attach them to sprites
    public AudioManager theAudio;
    public TextMeshProUGUI LdialogueText, Lresponse1Text, Lresponse2Text;
    public GameObject Lr1p;
    public GameObject Lr2p;
    
    //no buttons because i'm using weird techniques
    public Dialogue genDialogue;
    private LucyDialogue myDialogue;
    private string game = "Minesweeper";

    private DialogueSound dialogueSound; // declared for audio

    void Start()
    {
        //genDialogue = new Dialogue();
        Lr1p.SetActive(true);   //not necessary
        Lr2p.SetActive(true);   //not necessary
        //set dialogue up
        myDialogue = new LucyDialogue(Lr1p, Lr2p, LdialogueText, Lresponse1Text, Lresponse2Text);

        // AUDIO SETUP
        AudioClip lucyVoice = Resources.Load<AudioClip>("Owen/voice");
        if (lucyVoice == null)
        {
            Debug.LogError("Audio clip not found!");
            return;
        }

        // Create a new GameObject for the AudioSource
        GameObject audioGameObject = new GameObject("DialogueSoundAudioSource");
        AudioSource audioSource = audioGameObject.AddComponent<AudioSource>();

        // Assign the instance to the class-level dialogueSound variable
        dialogueSound = new DialogueSound(
            id: "lucyVoice",
            clip: lucyVoice,
            characterID: "Lucy",
            backgroundID: "Peanuts",
            source: audioSource
        );

        // Adjust the pitch directly through Unity on the AudioSource
        audioSource.pitch = 1f; 

        //reload state    
        p_dialogueNum = PeanutsDB.LucyDialogueNum;
        loadAffection(PeanutsDB.LucyAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), p_dialogueNum));

        //get to it
        onDialogue(p_dialogueNum);
    }
    
    void Update()
    {
        //continuosly make sure database is up to date
        PeanutsDB.LucyAffectionPts = getAffectionPoints();
        PeanutsDB.LucyDialogueNum = p_dialogueNum;
        //Debug.Log(p_responseNum.ToString());
    }

    /*a response button being hit will trigger this. 
    * decides how to respond to response through updating affection, setting next dialogue, and possibly starting a minigame
    */
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
                    p_dialogueNum = 4;
                    updateAffection(-5);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 3;
                    updateAffection(15);
                }
                p_responseNum = 0;

                break;
            case 2:
                if (p_responseNum == 1){
                    p_dialogueNum = 6;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 5;
                    updateAffection(10);
                }
                p_responseNum = 0;
                break;
            case 3: 
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(-20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 2;
                    updateAffection(15);
                }
                p_responseNum = 0;
                break;
            case 4:
                if (p_responseNum == 1){
                    p_dialogueNum = 8;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    updateAffection(-15);
                    p_dialogueNum = 7;
                }
                p_responseNum = 0;
                break;
            case 5:
                if (p_responseNum == 1){
                    p_dialogueNum = 10;
                    updateAffection(-20);
                } else if (p_responseNum == 2){
                    updateAffection(20);
                    p_dialogueNum = 9;
                }
                p_responseNum = 0;
                break;
            case 6:
                if (p_responseNum == 1){
                    p_dialogueNum = 9;
                    updateAffection(20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 10;
                    updateAffection(-5); 
                }
                p_responseNum = 0;
                break;
            case 7:
                p_dialogueNum = 15;
                break;
            case 8:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(-15);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 6;
                    updateAffection(20); 
                }
                p_responseNum = 0;
                break;
            case 9:
                if (p_responseNum == 1){
                    updateAffection(20);
                    initiateMiniGame(game);
                    //this should depend on winning (16) & losing (17).
                    p_dialogueNum = -1;
                } else if (p_responseNum == 2){
                    updateAffection(-20); 
                    p_dialogueNum = 10;
                }
                p_responseNum = 0;
                break;
            case 10:
                if (p_responseNum == 1){
                    p_dialogueNum = 7;
                    updateAffection(-30);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 11;
                    updateAffection(20); 
                }
                p_responseNum = 0;
                break;
            case 11:
                if (p_responseNum == 1){
                    p_dialogueNum = 12;
                    updateAffection(-15);
                } else if (p_responseNum == 2){
                    
                    updateAffection(25); 
                    initiateMiniGame(game);
                    //this should depend on winning (16) & losing (17).
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 12:
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-15);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 13;
                    updateAffection(10); 
                }
                p_responseNum = 0;
                break;
            case 13:
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-20);
                } else if (p_responseNum == 2){
                    
                    updateAffection(20); 
                    initiateMiniGame(game);
                    //this should depend on winning (16) & losing (17). //update affection points there or here?
                    p_dialogueNum = -1;
                }
                p_responseNum = 0;
                break;
            case 14:
                p_dialogueNum = 15;
                break;
            case 15:
                //froze out options
                break;
            case 16:
                //user won
                //post game ... give options to talk?
                if (p_responseNum == 1){
                    p_dialogueNum = 14;
                    updateAffection(-20);
                } else if (p_responseNum == 2){
                    p_dialogueNum = 18;
                    updateAffection(25); 
                }
                p_responseNum = 0;
                break;
            case 17:
                //user lost
                //post game... no options to talk
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
    */
    public void onDialogue(int d)
    {
        //if they just played a game
        if (p_dialogueNum == -1){
            //if they won
            if (MainPlayer.GetMiniGameStatus()==1)
            {
                updateAffection(-10);
                p_dialogueNum=16;
                d=16;
            }
            //or lost
            else if (MainPlayer.GetMiniGameStatus() == 0)
            {
                updateAffection(25);
                p_dialogueNum=17;
                d=17;
            }
            MainPlayer.SetMiniGameStatus(-1);   //reset game status
            Update();   //make sure DB gets updated
        }

        //check if user just got locked out
        else if (p_dialogueNum == 7 || p_dialogueNum ==  14 ){
            PeanutsDB.LucyLocked = 1;
            p_dialogueNum=15;
        }

        //check if user won
        if (getAffectionPoints() >= 100) //check if they won yet
        {
            UIElementHandler.UIGod.EndGame(true, "Lucy");
        } 
        //theAudio.loadSounds();
        myDialogue.v_displayDialogue(d);

        // AUDIO 
        dialogueSound.PlayForDuration(3f);
    }
    
}

