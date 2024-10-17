using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffectionUI : IAffectionObserver
{
   private TMP_Text affectionText;
   public AffectionUI(TMP_Text textComponent){
    affectionText = textComponent;
   }

   public void OnAffectionChanged(int newAffectionPoints){
    affectionText.text = "Affection Points: " + newAffectionPoints;
   }
}
