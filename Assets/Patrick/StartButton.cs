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
        inputPanel.SetActive(true);
    }
}
