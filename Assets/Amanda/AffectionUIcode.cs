using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffectionUI : IAffectionObserver
{
   private Text affectionText;
   public AffectionUI(Text affectionText){
    this.affectionText = affectionText;
   }

   public void OnAffectionChanged(int newAffectionPoints){
    affectionText.text = "Affection Points: " + newAffectionPoints;
   }
}
