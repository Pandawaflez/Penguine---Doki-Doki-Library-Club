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
                SceneManager.LoadScene("Lucy");
                break;
            case "Schroeder":
                Debug.Log("Talk to Schroeder (AKA Kevin)");
                //SceneManager.LoadScene("Schroeder");
                break;
            case "Snoopy":
                Debug.Log("Talk to Snoopy");
                SceneManager.LoadScene("Snoopy");
                break;
            case "Shaggy":
                Debug.Log("Talk to Norville");
                SceneManager.LoadScene("Shaggy");
                break;
            case "Daphne":
                Debug.Log("Talk to Daphne");
                SceneManager.LoadScene("Daphne");
                break;
            case "Fred":
                Debug.Log("Talk to Frederick");
                break;
            case "Sonic":
                Debug.Log("Talk to Sanic");
                SceneManager.LoadScene("Sonic");
                break;
            case "Shadow":
                Debug.Log("Talk to Shadow");
                SceneManager.LoadScene("Shadow");
                break;
            default:
                Debug.Log("Character " + character + " not found");
                break;
        }
    }

    /*[UnityTest] //tesst function:
    public IEnumerator sceneChangeSucessTest(){
        talkTo("Shaggy");
        Assert.
    }*/

}
