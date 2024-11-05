using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShaggyUI : MonoBehaviour
{
    public Button ShagR1;
    public Button ShagR2;
    public TextMeshProUGUI ShagDialogueText, ShagResponse1Text, ShagResponse2Text;

    private ShaggyScript ShagScript;
    // Start is called before the first frame update
    void Start()
    {
        ShagScript = new ShaggyScript();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
