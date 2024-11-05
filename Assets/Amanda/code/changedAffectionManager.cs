using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectionManager
{
    private const int MAX_AFFECTION = 100;
    private const int MIN_AFFECTION = -10;

    private static int sonicAffectionPoints = 0;
    private static int shadowAffectionPoints = 0;

    
    private List<IAffectionObserver> observers = new List<IAffectionObserver>();

    public AffectionManager(){
        //Load affection points from PlayerPrefs for sonic and shadow
        sonicAffectionPoints = PlayerPrefs.GetInt("SonicAffectionPoints", sonicAffectionPoints); 
        shadowAffectionPoints = PlayerPrefs.GetInt("ShadowAffectionPoints", shadowAffectionPoints); 
        
    }
    public void ChangeSonicAffectionPoints(int points){
        sonicAffectionPoints += points;
        //clamp affection points to the limits
        sonicAffectionPoints = Mathf.Clamp(sonicAffectionPoints, MIN_AFFECTION, MAX_AFFECTION);
        
        //save new value in playerprefs
        PlayerPrefs.SetInt("SonicAffectionPoints", sonicAffectionPoints);
        PlayerPrefs.Save();
        
        //notify observer
        NotifyChangedAffection("Sonic", sonicAffectionPoints);
    }

    public void ChangeShadowAffectionPoints(int points){
        shadowAffectionPoints += points;
        //clamp affection points to the limits
        shadowAffectionPoints = Mathf.Clamp(shadowAffectionPoints, MIN_AFFECTION, MAX_AFFECTION);
        
        //save new value in playerprefs
        PlayerPrefs.SetInt("ShadowAffectionPoints", shadowAffectionPoints);
        PlayerPrefs.Save();
        
        //notify observer
        NotifyChangedAffection("Shadow", shadowAffectionPoints);
    }

    public static int GetSonicAffectionPoints(){
        return sonicAffectionPoints;
    }

    public static int GetShadowAffectionPoints(){
        return shadowAffectionPoints;
    }

    // Setters for reloading affection points (useful when resetting)
    public void SetSonicAffectionPoints(int points)
    {
        sonicAffectionPoints = points;
        PlayerPrefs.SetInt("SonicAffectionPoints", sonicAffectionPoints);
        PlayerPrefs.Save();
    }

    public void SetShadowAffectionPoints(int points)
    {
        shadowAffectionPoints = points;
        PlayerPrefs.SetInt("ShadowAffectionPoints", shadowAffectionPoints);
        PlayerPrefs.Save();
    }
    
    public void RegisterObserver(IAffectionObserver observer){
        observers.Add(observer);
    }

    private void NotifyChangedAffection(string characterName, int affectionPoints){
        foreach (IAffectionObserver observer in observers){
            observer.OnAffectionChanged(characterName, affectionPoints);
        }
    }

    //reset affection points
    public void ResetSonicAffectionPoints()
    {
        // Reset values to 0 or any starting value you want
        sonicAffectionPoints = 0;

        // Save the reset values to PlayerPrefs
        //PlayerPrefs.SetInt("SonicAffectionPoints", 0);
        //PlayerPrefs.Save();
    }

    public void ResetShadowAffectionPoints()
    {
        // Reset values to 0 or any starting value you want
        shadowAffectionPoints = 0;

        // Save the reset values to PlayerPrefs
        //PlayerPrefs.SetInt("ShadowAffectionPoints", 0);
        //PlayerPrefs.Save();
    }
}