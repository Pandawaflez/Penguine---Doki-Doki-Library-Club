using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Schroeder : Peanuts
{
    public AudioManager theAudio;
    public TextMeshProUGUI LdialogueText, Lresponse1Text, Lresponse2Text;
    public GameObject Lr1p;
    public GameObject Lr2p;
    
    //no buttons because i'm using weird techniques
    public Dialogue dd;
    private LucyDialogue myDialogue;
    private string game = "Math";
    // Start is called before the first frame update
    void Start()
    {
        dd = new Dialogue();
        p_dialogueNum=1;
        dd.reg(this, 5);
    }

    // Update is called once per frame
    void Update()
    {
        p_dialogueNum=2;
        dd.up();
    }

}
