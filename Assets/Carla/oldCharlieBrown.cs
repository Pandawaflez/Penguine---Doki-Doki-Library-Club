
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OLDCharlieBrown : Peanuts
{
    //graphics
    //sfx
    //minigame

    /*
    public TextMeshProUGUI dialogueText, response1Text, response2Text;

    //dialogue order: 
    //0->a1|b2
    //1->a5|b2
    //2->a3|b4
    //3->a5|b6
    //4->a5|b-game
    //5-> 7
    //6->a5|b-game
    //7-> 7
    
  
    private string dialogue0 = "Hello. I'm Charlie Brown. I'd love to keep talking to you, as long as you keep your voice down. Afterall, we're in the Miami-Dade Public Library.";
    private string d0response1 = "Live a little Charlie! What harm will come from speaking loudly?";
    private string d0response2 = "Oh, of course! So nice to meet you Charlie";

    private string dialogue1 = "Don't you know the librarians can lock you up in the Ancient book room?! I can't associate with you anymore.";
    private string d1response1 = "Don't be such a scaredy cat Charlie Brown";
    private string d1response2 = "Good Grief! Good thing you warned me!";

    private string dialogue2 = "So what brings you to my corner of the library?";
    private string d2response1 = "I'm hunting rats";
    private string d2response2 = "I'm just looking for something to do while I wait for my little sister to pick out her comics.";

    private string dialogue3 = "Good Grief! Are there really rats in here?";
    private string d3response1 = "No smh that was clearly a joke";
    private string d3response2 = "Yeah but don't worry pookie, I'll keep you safe";

    private string dialogue4 = "Oh what a coincidence! I have a little sister roaming around too. Do you want to play a game with me while we wait?";
    private string d4response1 = "No I just want to read a book";
    private string d4response2 = "Holy Smokes yeah";

    private string dialogue5 = "I'm just going to go back to reading then...";

    private string dialogue6 = "Oh umm. Thank you. Well since you're here, want to play a game?";
    private string d6response1 = "Unfortch there's no rest for the wicked. See ya!";
    private string d6response2 = "Yes, my sweet prince!";

    private string dialogue7 = "I'm reading, sorry.";

    public string dialogue8 = "Thanks for playing with me!";
    

    //was public
    private void displayDialogue(string dialogue, string r1, string r2){
        //display the dialogue, call sfx, wait a few sec, display response
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
        //call sfx. should only play 3 sec
    }

    //game objects to set buttons active/deactive
    public GameObject r1p;
    public GameObject r2p;
    public void displayJustText(string dialogue){
        dialogueText.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
        //r1.gameObject.SetActive(false); //these didn't work for no reason smh
        //r2.gameObject.SetActive(false);
    }
    */
    //private int getDialogueNum(){
    //    return dialogueNum;
    //}

    //buttons to reset the buttons ('unclick' them)
    public Button r1;
    public Button r2;
    //private int responseNum = 0;

    //button one calls onclick
    public void hitResponse1(){
        responseNum = 1;
        Debug.Log("they hit it boss");
        //StartCoroutine(holdUp(10));
        //unselect button for next screen
        r1.Select();
        toNextDialogue();
    }

    //button 2 calls onclick
    public void hitResponse2(){
        responseNum = 2;
        //holdUp(1);
        r2.Select();
        toNextDialogue();
    }


/*
    private void initiateMiniGame(){
        //SceneManager.LoadScene("Pong", LoadSceneMode.Additive);
        SceneChanger.saveScene();
        SceneManager.LoadScene("Pong");

        dialogueNum = 8;
    }
*/

    //a button being hit will trigger this. decides how to respond to response
    private void toNextDialogue(){
        int d = getDialogueNum();
        switch(d){
            case 0:
                if (responseNum == 1){
                    dialogueNum=1;
                    updateAffection(-1);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(5);
                }
                responseNum = 0;
                break;
            case 1:
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(15);
                }
                responseNum = 0;

                break;
            case 2:
                //if r1, dialogueNum=3, else 4
                if (responseNum == 1){
                    dialogueNum = 3;
                    updateAffection(0);
                } else if (responseNum == 2){
                    dialogueNum = 4;
                    updateAffection(15);
                }
                responseNum = 0;
                break;
            case 3: 
                //if r1, dialogueNum=5, else 6
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-10);
                } else if (responseNum == 2){
                    dialogueNum = 6;
                    updateAffection(3);
                }
                responseNum = 0;
                break;
            case 4:
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(0);
                } else if (responseNum == 2){
                    updateAffection(5);
                    initiateMiniGame("Pong");
                    //dialogueNum = 8;
                }
                responseNum = 0;
                break;
            case 5:
                //player stops talking to charlie...
                //holdUp(5); //useless?
                dialogueNum=7;
                break;
            case 6:
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    //dialogueNum = 8;
                    updateAffection(8);
                    initiateMiniGame("Pong");
                }
                responseNum = 0;
                break;
            case 7:
                //stuck
                break;
            case 8:
                //post game
                //give user option to keep talking?
                break;
        }
        onDialogue(dialogueNum);
        Debug.Log(string.Format("current affection points: {0}", getAffectionPoints()));
    }

    //prints the new dialogue
    /*
    private void onDialogue(int d){
        switch(d){
            case 0:
            r2p.SetActive(true);
            r1p.SetActive(true);
            Debug.Log("first time here huh");
                displayDialogue(dialogue0, d0response1, d0response2);
                
                break;
            case 1:
            Debug.Log("here i stand");
                displayDialogue(dialogue1, d1response1, d1response2);
                
                break;
            case 2:
                displayDialogue(dialogue2, d2response1, d2response2);
                
                break;
            case 3: 
                displayDialogue(dialogue3, d3response1, d3response2);
                
                break;
            case 4:
                displayDialogue(dialogue4, d4response1, d4response2);
                
                break;
            case 5:
                myDialogue.displayJustText(dialogue5);
                
                break;
            case 6:
                displayDialogue(dialogue6, d6response1, d6response2);
                
                break;
            case 7:
                myDialogue.displayJustText(myDialogue.getDialogue70());
                //stuck
                break;
            case 8:
                CharlieDialogue.displayJustText(dialogue8);
                break;
        }
    }
    */

    //public AudioManager theAudio;
    public void onDialogue(int d){
        //theAudio.loadSounds();
        //myDialogue.displayDialogue(d, Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        myDialogue.displayDialogue(d);
    }


    private CharlieDialogue myDialogue;
    public Dialogue genDialogue;
    
    public TextMeshProUGUI CdialogueText, Cresponse1Text, Cresponse2Text;
    public GameObject Cr1p;
    public GameObject Cr2p;

    //spriteRenderer

   
    void Start(){
        //genDialogue = new Dialogue();
        myDialogue = new CharlieDialogue(Cr1p, Cr2p, CdialogueText, Cresponse1Text, Cresponse2Text);
        //theAudio = new AudioManager();
        /*
        CdialogueText = myDialogue.dialogueText;
        Cresponse1Text = myDialogue.response1Text;
        Cresponse2Text = myDialogue.response2Text;
        Cr1p = myDialogue.r1p;
        Cr2p = myDialogue.r2p;
        */
        dialogueNum = PeanutsDB.CharlieDialogueNum;
        loadAffection(PeanutsDB.CharlieAffectionPts);
        Debug.Log(string.Format("starting with {0} affection points on dialoge {1}", getAffectionPoints(), dialogueNum));
        onDialogue(dialogueNum);
        /*
        dialogueText.SetText(dialogue0);
        response1Text.SetText(d0response1);
        response2Text.SetText("my sweet sweet charlie prince...");
        */
    }
    
    void Update(){
        PeanutsDB.CharlieAffectionPts = getAffectionPoints();
        PeanutsDB.CharlieDialogueNum = dialogueNum;
        /*
        int d = getDialogueNum();
        switch(d){
            case 0:
                displayDialogue(dialogue0, d0response1, d0response2);
                displayJustText("umm");
                //play sfx here or in above?
                //if r1, dialogueNum=1, else 2
                if (responseNum == 1){
                    dialogueNum=1;
                    updateAffection(-1);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(5);
                }
                responseNum = 0;
                
                break;
            case 1:
                displayDialogue(dialogue1, d1response1, d1response2);
                //if r1, dialogueNum=5, else 2
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 2;
                    updateAffection(15);
                }
                responseNum = 0;

                break;
            case 2:
                displayDialogue(dialogue2, d2response1, d2response2);
                //if r1, dialogueNum=3, else 4
                if (responseNum == 1){
                    dialogueNum = 3;
                    updateAffection(0);
                } else if (responseNum == 2){
                    dialogueNum = 4;
                    updateAffection(15);
                }
                responseNum = 0;
                break;
            case 3: 
                displayDialogue(dialogue3, d3response1, d3response2);
                //if r1, dialogueNum=5, else 6
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-10);
                } else if (responseNum == 2){
                    dialogueNum = 6;
                    updateAffection(3);
                }
                responseNum = 0;
                break;
            case 4:
                displayDialogue(dialogue4, d4response1, d4response2);
                //if r1, dialogueNum=5, else playMini()
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(0);
                } else if (responseNum == 2){
                    dialogueNum = 8;
                    updateAffection(5);
                    initiateMiniGame();
                }
                responseNum = 0;
                break;
            case 5:
                displayDialogue(dialogue5, "", "");
                //player stops talking to charlie...
                holdUp(5);
                dialogueNum=7;
                break;
            case 6:
                displayDialogue(dialogue6, d6response1, d6response2);
                //if r1, dialogueNum=5, else playMini()
                if (responseNum == 1){
                    dialogueNum = 5;
                    updateAffection(-2);
                } else if (responseNum == 2){
                    dialogueNum = 8;
                    updateAffection(8);
                    initiateMiniGame();
                }
                responseNum = 0;
                break;
            case 7:
                displayJustText(dialogue7);
                //stuck
                break;
            case 8:
                displayJustText(dialogue8);
                break;
            /*
            default:
                displayDialogue("Whoops i hit my head! who are you?", "bruh", "no worries my sweet prince!");
            
        }
        */
    }
    
}

