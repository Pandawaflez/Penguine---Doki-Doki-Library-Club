using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overworldDebugMenu : MonoBehaviour
{
    public void talkTo( string character ){
        Debug.Log("Character:");
        switch ( character ){
            case "Charlie":
                Debug.Log("Talk to Chuck");
                SceneManager.LoadScene("Level1");
                break;
            case "Lucy":
                Debug.Log("Talk to Lucy");
                break;
            case "Schroeder":
                Debug.Log("Talk to Schroeder (AKA Kevin)");
                break;
            case "Snoopy":
                Debug.Log("Talk to Snoopy");
                break;
            case "Shaggy":
                Debug.Log("Talk to Norville");
                break;
            case "Daphne":
                Debug.Log("Talk to Daphne");
                break;
            case "Fred":
                Debug.Log("Talk to Frederick");
                break;
            case "Sonic":
                Debug.Log("Talk to Sanic");
                break;
            case "Shadow":
                Debug.Log("Talk to Shadow");
                break;
            default:
                Debug.Log("Character " + character + " not found");
                break;
        }
    }
}
