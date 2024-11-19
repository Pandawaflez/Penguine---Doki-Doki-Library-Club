using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//not used
public class CharlieManager : MonoBehaviour
{
    public CharlieBrown charlie;
    // Start is called before the first frame update
    void Start()
    {
        charlie = Instantiate(charlie) as CharlieBrown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
