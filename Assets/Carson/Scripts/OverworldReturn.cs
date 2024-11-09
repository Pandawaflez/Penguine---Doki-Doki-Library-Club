using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldReturn : MonoBehaviour
{
    public void returnToOverworld(){
        SceneManager.LoadScene("Overworld");
    }
}
