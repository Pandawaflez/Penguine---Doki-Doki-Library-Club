//used for testing to see if my stuff worked 


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class checkaffectionscript : MonoBehaviour, IAffectionObserver
{
    private AffectionManager affectionManager;
     public GameObject examplePause;
    public TMP_Text sonicsText;
     public TMP_Text shadowsText;

    void Start()
    {
        affectionManager = new AffectionManager();
        affectionManager.RegisterObserver(this);  // Register this script as an observer
        UpdateAffectionDisplay();
        examplePause.SetActive(false);   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (examplePause.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        examplePause.SetActive(true);
        Debug.Log($"sonic affection: {affectionManager.GetShadowAffectionPoints()}");
        //UpdateAffectionDisplay();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        examplePause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void UpdateAffectionDisplay()
    {
        sonicsText.text = $"Sonic Affection: {affectionManager.GetSonicAffectionPoints()}";
        shadowsText.text = $"Shadow Affection: {affectionManager.GetShadowAffectionPoints()}";
    }

    // Implement the observer method to update the text fields when affection changes
    public void OnAffectionChanged(string characterName, int affectionPoints)
    {
        if (characterName == "Sonic")
        {
            sonicsText.text = $"Sonic Affection: {affectionPoints}";
        }
        else if (characterName == "Shadow")
        {
            shadowsText.text = $"Shadow Affection: {affectionPoints}";
        }
    }
}

*/
