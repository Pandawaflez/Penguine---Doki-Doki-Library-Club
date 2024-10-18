using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject inputPanel;  // Assign via Inspector

    private void Start()
    {
        inputPanel.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        // Show the input field when the Play button is clicked
        MainPlayer.SetBCMode(false);
        inputPanel.SetActive(true);
    }

    public void OnBCModeClicked()
    {
        //same as above but set BCMode True;
        MainPlayer.SetBCMode(true);
        inputPanel.SetActive(true);
    }
}
