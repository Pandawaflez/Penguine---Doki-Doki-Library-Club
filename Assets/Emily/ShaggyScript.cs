using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
//using System.Data.SqlClient;

public class ShaggyScript : Scooby
{
    //buttons for dialogue
    public Button ShagR1;
    public Button ShagR2;

    public int responseNum = 0;

    //selection of dialogues
    public void hitShagResponse1()
    {
        responseNum = 1;
        Debug.Log("Response 1 chosen");
        ShagR1.Select();
    }

    public void hitShagResponse2()
    {
        responseNum = 2;
        Debug.Log("Response 2 chosen");
        ShagR2.Select();
    }

    private ShagDialogue mvpShagDialogue;

    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;
    public GameObject Shag1p;
    public GameObject Shag2p;

    /*public string ShagSpeak;
    public void FetchDialoguePrompt(string dialoguePrompt){
        using (SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=ShaggyDialogue;Integrated Security=SSPI")) 
        using (SqlCommand cmd = new SqlCommand("SELECT Prompts FROM ShaggyDialogue.Prompts WHERE Prompts = @Prompts", connection))
        {
            cmd.Parameters.AddWithValue("Promps", dialoguePrompt);
            connection.Open();
            using (var reader = cmd.ExecuteReader()){
                if (reader.Read()){ 
                    string dialogue1 = reader.GetString(reader.GetOrdinal("Prompts"));
                    Console.WriteLine(dialogue1);
                }
                else {
                    Debug.Log("No more prompts");
                    //Console.WriteLine("No more prompts");
                }
            }
        }   
    }*/
    void Update() { }

}
