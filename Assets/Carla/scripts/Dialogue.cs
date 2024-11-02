using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class Dialogue
{
    public TextMeshProUGUI dialogueText, response1Text, response2Text;
    public GameObject r1p;
    public GameObject r2p;
    
    private string _genericDialogue = "Who am I?";
    private string _genericResponse1 = "Bro";
    private string _genericResponse2 = "ruh roh";

    //public void v_displayDialogue(int d)
    public virtual void v_displayDialogue(int d)
    {
    //public virtual void displayDialogue(int d, GameObject cr1p, GameObject cr2p, TextMeshProUGUI cdt, TextMeshProUGUI cr1t, TextMeshProUGUI cr2t){
        dialogueText.SetText(_genericDialogue);
        response1Text.SetText(_genericResponse1);
        response2Text.SetText(_genericResponse2);
    }

    //sets the text in dialogue and response panels
    protected void displayRealDialogue(string dialogue, string r1, string r2)
    {
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    //sets the text in dialogue panel and removes response panels
    protected void displayJustText(string dialogue)
    {
        dialogueText.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
    }

/*
    public Schroeder st;
    public void reg(Schroeder s, int d) //ig ref is the same thing as pointer????
    {
        st = s;
        Debug.Log(st.getDialogueNum().ToString());
    }
    public void up(){
        Debug.Log("calling up");
        Debug.Log(st.getDialogueNum().ToString());
    }
*/
}

public class CharlieDialogue : Dialogue
{
    //dialogue order: 
    //0->a1|b2 -5 +20
    //1->a5|b2 -10 +30
    //2->a4|b3 +20 -5
    //3->a5|b6 -10 +45
    //4->a5|b-game -5 +30
    //5-> 7 (end)
    //6->a5|b-game -2 +15
    //7-> loop
    //8-> after game +30?   //multiple ways to get to 100 pts
    //-1 game msg
    
  
    private string dialogue0 = "Hello. I'm Charlie Brown.\nI'd love to keep talking to you, as long as you keep your voice down. Afterall, we're in the Miami-Dade Public Library.";
    private string d0response1 = "Live a little Charlie! What harm will come from speaking loudly?";
    private string d0response2 = "Oh, of course! So nice to meet you Charlie. I'm " + MainPlayer.GetPlayerName() + ".";

    private string dialogue1 = "Don't you know the librarians can lock you up in the Ancient book room?! I can't associate with you anymore.";
    private string d1response1 = "Don't be such a scaredy cat Charlie Brown.";
    private string d1response2 = "Good Grief! Good thing you warned me!";

    private string dialogue2 = "So what brings you to my corner of the library, " + MainPlayer.GetPlayerName() + "?";
    private string d2response1 = "I'm just looking for something to do while I wait for my little sister to pick out her comics.";
    private string d2response2 = "I'm hunting rats.";


    private string dialogue3 = "Good Grief! Are there really rats in here?";
    private string d3response1 = "Umm no Charlie Brown. That was a joke.";
    private string d3response2 = "Yeah but don't worry pookie, I'll keep you safe.";

    private string dialogue4 = "Oh what a coincidence! I have a little sister roaming around too. \nDo you want to play a game with me while we wait?";
    private string d4response1 = "No I just want to get out of here.";
    private string d4response2 = "Holy Smokes yeah!";

    private string dialogue5 = "I'm just going to go back to reading then...";

    private string dialogue6 = "Oh umm. Thank you. \nWell since you're here, want to play a game?";
    private string d6response1 = "Unfortch there's no rest for the wicked. See ya!";
    private string d6response2 = "Yes, my sweet prince!";

    private string dialogue7 = "I'm reading, sorry.";

    private string dialogue8 = "Well, thanks for playing " + MainPlayer.GetPlayerName() + "!";

    private string dialogueG = "Good luck!";

    //what's that got to do with anything


    //constructor
    public CharlieDialogue(GameObject Cr1p, GameObject Cr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t)
    {
        dialogueText =  dt;
        response1Text = r1t;
        response2Text = r2t;
        r1p = Cr1p;
        r2p = Cr2p;
    }
 
    //public void v_displayDialogue(int d)
    public override void v_displayDialogue(int d)
    {
        r2p.SetActive(true);
        r1p.SetActive(true);
        switch(d)
        {
            case 0:
            //r2p.SetActive(true);
            //r1p.SetActive(true);
            Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2);
                break;
            case 1:
            Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2);
                
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2);
                
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2);
                
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2);
                
                break;
            case 5:
                displayJustText(dialogue5);
                
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2);
                
                break;
            case 7:
                displayJustText(dialogue7);
                //stuck
                break;
            case 8:
                displayJustText(dialogue8);
                break;
            case -1:
                displayJustText(dialogueG);
                break;
            default:
                Debug.Log("no dialogue in d class");
                break;
        }
    }

/*
    private void displayRealDialogue(string dialogue, string r1, string r2)
    {
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    private void displayJustText(string dialogue)
    {
        dialogueText.SetText(dialogue);
        //dt.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
        //r1.gameObject.SetActive(false); //these didn't work for no reason smh
        //r2.gameObject.SetActive(false);
    }
*/

}


public class LucyDialogue : Dialogue
{
    //dialogue order: 
    //0-> a1|b2 -5 +20
    //1-> a4|b3 -5 +15
    //2-> a6|b5 +20 +10
    //3-> a7|b2 -20 +15
    //4-> a8|b7 +20 -15
    //5-> a10|b9 -20 +20
    //6-> a9|b10 +20 -5
    //7-> 15 end
    //8-> a7|b6 -15 +20
    //9-> a-game|b10 +20 -20
    //10->a7|b11 -30 +20
    //11->a12|b-game -15 +25
    //12->a14|b13 -15 +10
    //13->a14|b-game -20 +20
    //14-> 15 bad end
    //15-> loop bad end
    //16-> a14|b18 (after win game -10) -20 +25
    //17-> after lose game (no options) +25
    //18-> good 
    //p lose +25 p win -10
    
  
    private string dialogue0 = "You look lost, little donut. I'll take pity on you and give you some advice, for a nickel. Welcome to Lucy's corner.";
    private string d0response1 = "Bruh you ain't getting my nickels";
    private string d0response2 = "Deal of the century. Please enlighten me!";

    private string dialogue1 = "Fine! I'll give you a free sample then. Goodness you are stingy.";
    private string d1response1 = "What's this advice huh";
    private string d1response2 = "Oh, well thanks I suppose... I'll try it out";

    private string dialogue2 = "I guess you're a pretty smart one afterall, "+MainPlayer.GetPlayerName()+"!\nWell, I was going to tell you that you'd better start walking around a little more mindfully. Those librarians are always watching.";
    private string d2response1 = "Good Grief! Are they watching us right now?";
    private string d2response2 = "... Really?";

    private string dialogue3 = "My advice is to treat a lady with a little more respect! What is it with people these days?!";
    private string d3response1 = "Do you have any actually good advice?";
    private string d3response2 = "Jeez, my bad Lucy. I'll be better for you :)";

    private string dialogue4 = "My advice is to get a pair of eyes! Nobody wants to talk to a nickel-less wanderer.";
    private string d4response1 = "Golly Lucy, like you're right, but it's not my fault I'm nickel-less! That crazy Shaggy kid robbed me for sandwich money for him and his beastie";
    private string d4response2 = "Bro! I'm not nickel-less, I just don't want to give them to you!";

    private string dialogue5 = "Of course! I've never made a mistake in my life. I thought I did once, but I was wrong.";
    private string d5response1 = "So... that's a mistake.";
    private string d5response2 = "You are my idol, Lucy Van Pelt.";

    private string dialogue6 = "They know not to bother me. Nobody tells me what to do! Nobody!!";
    private string d6response1 = "You are a legend among characters, Lucy";
    private string d6response2 = "What if I told you that you, infact, are a product of a society of tellers.";

    private string dialogue7 = "Well you don't deserve any advice! Bug off, cretin!!";

    private string dialogue8 = "Harrumph!\nWell, that's why you've got to carry yourself with a little more respect, "+MainPlayer.GetPlayerName()+"! Then people won't bother you";
    private string d8response1 = "Respect?! You carry yourself like a dictator!";
    private string d8response2 = "Oh, does that really work? I guess you're pretty good at it...";

    private string dialogue9 = "You're lucky I like flattery. So, do you want to play a game?";
    private string d9response1 = "Lucy, of course I would.";
    private string d9response2 = "Dude. That was sarcasm.";

    private string dialogue10 = "Oh so we've got a smarty pants on our hands, is that so?!";
    private string d10response1 = "Hardly much competition around here.";
    private string d10response2 = "I'm sorry Lucy, I was just trying to keep up with your unbeatable witiness! Let me repent.";

    private string dialogue11 = "You should obviously know that no one can keep up with me. So let's see your talent in a game!";
    private string d11response1 = "I've seen your wiles with Charlie, so there's no way.";
    private string d11response2 = "It would be my honor to lose to you!";

    private string dialogue12 = "Hanging around Charlie Brown, huh? What's that downer been up to. Downering? Ugh! \nDon't bring him up again.";
    private string d12response1 = "You're the downerer! Of others!";
    private string d12response2 = "Well that's why I'm over here talking to you instead of him.";

    private string dialogue13 = "Hmm, that's what I thought. Well, prove it with a game?";
    private string d13response1 = "Why must we perpetrate the cycle of pain...";
    private string d13response2 = "Well... I'll try.";

    private string dialogue14 = "I can't take this attitude any longer! Don't bring me down with these words of despair! Good Grief! You're just like Charlie Brown!";

    public string dialogue15 = "You again? Don't bother!";

    private string dialogue16 = "Beginner's luck of course.";
    private string d16response1 = "Will you ever gain self-awareness?";
    private string d16response2 = "Ahh Lucy, it definitely was just your godliness rubbing off on me!";

    private string dialogue17 = "Hah! Well good game against me, the winner, of course.";

    private string dialogue18 = "Flattery will get you everywhere, you dork.";

    private string dialogueG = "Good luck... you'll need it";

    //good dialogue end loop? or kicks you out of library...?

    //constructor
    public LucyDialogue(GameObject Lr1p, GameObject Lr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t)
    {
        dialogueText =  dt;
        response1Text = r1t;
        response2Text = r2t;
        r1p = Lr1p;
        r2p = Lr2p;
    }

    //public void v_displayDialogue(int d)
    public override void v_displayDialogue(int d)
    {
        switch(d)
        {
            case 0:
            r2p.SetActive(true);
            r1p.SetActive(true);
            Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2);
                break;
            case 1:
            Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2);
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2);
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2);
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2);
                break;
            case 5:
                displayRealDialogue(dialogue5, d5response1, d5response2);
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2);
                break;
            case 7:
                displayJustText(dialogue7);
                break;
            case 8:
                displayRealDialogue(dialogue8, d8response1, d8response2);
                break;
            case 9:
                displayRealDialogue(dialogue9, d9response1, d9response2);
                break;
            case 10: 
                displayRealDialogue(dialogue10, d10response1, d10response2);
                break;
            case 11:
                displayRealDialogue(dialogue11, d11response1, d11response2);
                break;
            case 12:
                displayRealDialogue(dialogue12, d12response1, d12response2);
                break;
            case 13:
                displayRealDialogue(dialogue13, d13response1, d13response2);
                break;
            case 14: 
                 displayJustText(dialogue14);
                break;
            case 15:
                 displayJustText(dialogue15);
                 break;
            case 16:
                displayRealDialogue(dialogue16, d16response1, d16response2);
                break;
            case 17:
                displayJustText(dialogue17);
                break;
            case 18:
                displayJustText(dialogue18);
                break;
            default:
                displayJustText("I'm at a small loss for conversation right now...");
                break;
        }
    }
/*
    private void displayRealDialogue(string dialogue, string r1, string r2)
    {
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    private void displayJustText(string dialogue)
    {
        dialogueText.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
    }
*/

}

public class SnoopyDialogue : Dialogue
{
    //dialogue order:
    //0-> a1|b2 +20 -5
    //1-> a3|b4 +10 +45
    //2-> a5|b6 +25 +40
    //3-> a4|b7 +30 -10
    //4-> a7|b-game -5 +20
    //5-> a8|b9 +30 -20
    //6-> a9|b10 -10 +20
    //7-> a10|b8 +20 +10
    //8-> a-game|b11 +20 -10
    //9-> a11|b-game -5 +25
    //10->a11|b-game -5 +20
    //11-> 12
    //12 stuck
    //13 user won game +15
    //14 user lost game +30

    private string dialogue0 = "Another person? I hope you're not going to ask for me to cook dinner... although I would understand why.";
    private string d0response1 = "No, although I, "+MainPlayer.GetPlayerName()+", do admire you, chef-extraordinaire";
    private string d0response2 = "Snoopy, you made colored beans and popcorn for Thanksgiving.";

    private string dialogue1 = "Well it's good to be appreciated! Do you have more than just words for me though?";
    private string d1response1 = "I can give pets and love?";
    private string d1response2 = "I have some very fine ham and steak, and some worms for your little friends!";

    private string dialogue2 = "And it was good, you blockhead. You'll find a better companion than me before you find the Great Pumpkin!";
    private string d2response1 = "You're right Snoopy, that's my bad! \nEveryone apologized to Charlie for taking him for granted, but what about you?";
    private string d2response2 = "No, it was good! That's what I meant. Nothing like magic beans!";

    private string dialogue3 = "Hmmm, I'll keep that in mind! But can you give me some music?";
    private string d3response1 = "Oh, like a smooth jazz solo?";
    private string d3response2 = "I've got SnoopDog queued up!";

    private string dialogue4 = "A human of taste! Say, what do you think about a little war game, "+MainPlayer.GetPlayerName()+"?";
    private string d4response1 = "War? Or fetch?";
    private string d4response2 = "Boy I can't wait! I hope this is a reference to the Red Baron...";

    private string dialogue5 = "Hah! Well that's nice to hear.";
    private string d5response1 = "As nice as Schroeder's crooning?";
    private string d5response2 = "Yeah, sorry Charlie Brown didn't thank you.";

    private string dialogue6 = "Hah! I thought so too, though of course I know how to make fancier food than that.";
    private string d6response1 = "A far better cook than Charlie Brown, I'll say!";
    private string d6response2 = "A jack of all trades, I would say!.";

    private string dialogue7 = "Good Grief! I will never understand the human race. Don't you have any taste?";
    private string d7response1 = "Shoot! I mean... some shooting taste? Do you?";
    private string d7response2 = "Erm... I mean I do like Schroeder?";

    private string dialogue8 = "Well, nothing can beat Schroeder, other than Beethoven himself! \nSomewhat like beating me in Minesweeper...";
    private string d8response1 = "Well said. I'll take you on!";
    private string d8response2 = "Wait, but I could beat you so... isn't this is wrong?";

    private string dialogue9 = "Hey now. Don't disrespect Charlie like that. You're walking on thin... mines.";
    private string d9response1 = "Was that a threat?";
    private string d9response2 = "Was that a minesweeper reference?";

    private string dialogue10 = "Now I've got some skill in the old trade of shooting that wily Red Baron out of the sky! \nIn fact, I think I got him to hit the ground a while back... Should we go in search?";
    private string d10response1 = "Wow Snoopy that sounds a little dangerous though...";
    private string d10response2 = "Oh some minesweeper activities? Sign me up!";

    private string dialogue11 = "Gah! I'm taking a break from humans and going back to my birdies.";

    private string dialogue12 = "You're disrupting a great Red Baron dogfight daydream! Shoo!";

    private string dialogue13 = "... Respectable.";

    private string dialogue14 = "Hah! Another victory for K-9s! Good game puppy!";

    private string dialogueG = "Good luck!";

    //constructor
    public SnoopyDialogue(GameObject Lr1p, GameObject Lr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t)
    {
        dialogueText =  dt;
        response1Text = r1t;
        response2Text = r2t;
        r1p = Lr1p;
        r2p = Lr2p;
    }

    //public void v_displayDialogue(int d)
    public override void v_displayDialogue(int d)
    {
        r2p.SetActive(true);
        r1p.SetActive(true);
        switch(d)
        {
            case 0:
                //r2p.SetActive(true);
                //r1p.SetActive(true);
                Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2);
                break;
            case 1:
                Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2);
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2);
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2);
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2);
                break;
            case 5:
                displayRealDialogue(dialogue5, d5response1, d5response2);
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2);
                break;
            case 7:
                displayRealDialogue(dialogue7, d7response1, d7response2);
                break;
            case 8:
                displayRealDialogue(dialogue8, d8response1, d8response2);
                break;
            case 9:
                displayRealDialogue(dialogue9, d9response1, d9response2);
                break;
            case 10: 
                displayRealDialogue(dialogue10, d10response1, d10response2);
                break;
            case 11:
                displayJustText(dialogue11);
                break;
            case 12:
                displayJustText(dialogue12);
                break;
            case 13:
                displayJustText(dialogue13);
                break;
            case 14:
                displayJustText(dialogue14);
                break;
            default:
                //displayJustText(dialogue7);
                Debug.Log("no dialogue in d class");
                break;
        }
    }
/*
    private void displayRealDialogue(string dialogue, string r1, string r2)
    {
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    private void displayJustText(string dialogue)
    {
        dialogueText.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
    }
*/
}

public class SchroederDialogue : Dialogue
{
    //dialogue order:
    //0-> a1|b2 +20 -5           //START: & default: great pumpkin waltz
    //1-> a3|b4 +20 +5
    //2-> a5|b3 +15 +5
    //3-> a6|b7 -15 +25         //fur elise
    //4-> a7|b6 +20 -20
    //5-> a8|b9 +5 -5           //linus and lucy
    //6-> a11|b7 -10 +10
    //7-> a11|b10 +5 +15
    //8-> a7|b9 +15 -10
    //9 -> 12                   //fly me to the moon
    //10-> a14|b-game -5 +20
    //11-> a10|b9 +10 -20        //fly me to the moon
    //12 end stuck              //default GPW
    //13 won +25                //default GPW
    //14 lost -5                //default GPW


    private string dialogue0 = "shhh... I'm playing piano.";
    private string d0response1 = "It's what drew me to this corner actually! So beautiful.";
    private string d0response2 = "Is this Mozart? It's very nice.";

    private string dialogue1 = "Yes...";
    private string d1response1 = "Do you have any other tunes?";
    private string d1response2 = "Makes me want to dance... pity you can't join while you play!";

    private string dialogue2 = "Of course not.";
    private string d2response1 = "Oh! I meant Vince Guaraldi?";
    private string d2response2 = "Shoot! I'll confess I'm not very well versed... can you play some more?";

    private string dialogue3 = "Of course. I have many.";
    private string d3response1 = "Not another Beethoven!";
    private string d3response2 = "This is a joy, Schroeder.";

    private string dialogue4 = "The pianist need only piano.";
    private string d4response1 = "Well said, sire. I can see you are a man of refinement.";
    private string d4response2 = "Isn't that a bit intense? You're only a boy.";

    private string dialogue5 = "I beg your pardon?";
    private string d5response1 = "Ahh, nevermind nevermind. Say, what do you know of the Peanuts Waltz?";
    private string d5response2 = "Your true composer, you know? The trio?";

    private string dialogue6 = "Beethoven was only 10 when he started composing. What were YOU doing at 10?";
    private string d6response1 = "Enjoying life?";
    private string d6response2 = "Uhh, good point, good point. I admire your drive.";

    private string dialogue7 = "Yes, well. Thank you.";
    private string d7response1 = "Schroeder, you charmer!";
    private string d7response2 = "Thank you, Schroeder!";

    private string dialogue8 = "Let's say I did know what you were talking about... I think it would go something like this.";
    private string d8response1 = "That's perfect!";
    private string d8response2 = "Aha! Caught you in the 4th wall Schroeder.";

    private string dialogue9 = "I don't know what ever you mean. I've got to get back to practicing.";

    private string dialogue10 = "You are awful chatty. Why don't you play a math game over there while I practice?";
    private string d10response1 = "But Schroeder! I just want to spend some time with you!";
    private string d10response2 = "Ok, I'll come back with a high score for you.";

    private string dialogue11 = "You sound just like Lucy Van Pelt. If you'll excuse me, I've got to get back to practicing.";
    private string d11response1 = "Wait, no I'm sorry! Let me hang out, I'll keep it down.";
    private string d11response2 = "You are one cold dude, Schroeder.";

    private string dialogue12 = "You can listen but I'm busy playing.";

    private string dialogue13 = "Nice job. Now sit and listen.";

    private string dialogue14 = "Hmm. Quiet up then, you haven't demonsrated enough intellect to continue conversing.";

    private string dialogueG = "Good luck.";

    //constructor
    public SchroederDialogue(GameObject Lr1p, GameObject Lr2p, TextMeshProUGUI dt, TextMeshProUGUI r1t, TextMeshProUGUI r2t)
    {
        dialogueText =  dt;
        response1Text = r1t;
        response2Text = r2t;
        r1p = Lr1p;
        r2p = Lr2p;
    }

    //public void v_displayDialogue(int d)
    public override void v_displayDialogue(int d)
    {
        r2p.SetActive(true);
        r1p.SetActive(true);
        switch(d)
        {
            case 0:
                //r2p.SetActive(true);
                //r1p.SetActive(true);
                Debug.Log("first time here huh");
                displayRealDialogue(dialogue0, d0response1, d0response2);
                break;
            case 1:
                Debug.Log("here i stand");
                displayRealDialogue(dialogue1, d1response1, d1response2);
                break;
            case 2:
                displayRealDialogue(dialogue2, d2response1, d2response2);
                break;
            case 3: 
                displayRealDialogue(dialogue3, d3response1, d3response2);
                break;
            case 4:
                displayRealDialogue(dialogue4, d4response1, d4response2);
                break;
            case 5:
                displayRealDialogue(dialogue5, d5response1, d5response2);
                break;
            case 6:
                displayRealDialogue(dialogue6, d6response1, d6response2);
                break;
            case 7:
                displayRealDialogue(dialogue7, d7response1, d7response2);
                break;
            case 8:
                displayRealDialogue(dialogue8, d8response1, d8response2);
                break;
            case 9:
                displayJustText(dialogue9);
                break;
            case 10: 
                displayRealDialogue(dialogue10, d10response1, d10response2);
                break;
            case 11:
                displayRealDialogue(dialogue11, d11response1, d11response2);
                break;
            case 12:
                displayJustText(dialogue12);
                break;
            case 13:
                displayJustText(dialogue13);
                break;
            case 14:
                displayJustText(dialogue14);
                break;
            default:
                Debug.Log("no dialogue in d class");
                break;
        }
    }
/*
    private void displayRealDialogue(string dialogue, string r1, string r2)
    {
        dialogueText.SetText(dialogue);
        response1Text.SetText(r1);
        response2Text.SetText(r2);
    }

    private void displayJustText(string dialogue)
    {
        dialogueText.SetText(dialogue);
        r2p.SetActive(false);
        r1p.SetActive(false);
    }
*/
}

