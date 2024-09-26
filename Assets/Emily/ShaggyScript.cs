using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class ShaggyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI ShdialogueText, Shresponse_1_Text, Shresponse_2_Text;

    private string ShagIntro = "Hey, my name is Shaggy. You seem pretty groovy!";
    private string ResponseD1 = "Thanks! You do too.";
    private string ResponseD2 = "Thanks man. How do you feel about Scooby Snacks?";

    private string ShagDia_1 = ".........tbd.......";
    private Text displaytext;

    public void displayShagDia(string d1, string res1, string res2)
    {
        ShdialogueText.SetText(ShagIntro);
        Shresponse_1_Text.SetText(ResponseD1);
        Shresponse_2_Text.SetText(ResponseD2);
    }

    public void textDisplay()
    {
        displaytext.text = ".....tbd........";
    }

    public GameObject r1S;
    public GameObject r2S;

    public void justTextDisplay(string t)
    {
        ShdialogueText.SetText(ShagIntro);
        r1S.SetActive(false);
        r2S.SetActive(false);
    }

    public Button res1;
    public Button res2;
    public int resnum = 0;

    public void ShagResp1()
    {
        resnum = 1;
        Debug.Log("Respone 1 chosen");
        res1.Select();
    }

    public void ShagResp2()
    {
        resnum = 2;
        Debug.Log("Response 2 chosen");
        res2.Select();
    }
}
