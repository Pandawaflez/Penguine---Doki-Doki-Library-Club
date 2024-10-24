using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffectionUI : IAffectionObserver
{
   private TMP_Text affectionText;
   public AffectionUI(TMP_Text affectionText){
    this.affectionText = affectionText;
   }


   public void OnAffectionChanged(string characterName, int affectionPoints){
    affectionText.text = $"{characterName} Affection Points: {affectionPoints}";
   }
}
