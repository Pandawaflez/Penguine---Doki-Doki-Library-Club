using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectionManager 
{
    private const int MAX_AFFECTION = 100;
    private const int MIN_AFFECTION = -10;
    
    private int affectionPoints;
    
    private List<IAffectionObserver> observers = new List<IAffectionObserver>();

    public void changeAffectionPoints(int points){
        affectionPoints += points;

        //clamp affection points to the limits
        affectionPoints = Mathf.Clamp(affectionPoints, MIN_AFFECTION, MAX_AFFECTION);
        
        NotifyChangedAffection();
    }

    public int GetAffectionPoints(){
        return affectionPoints;
    }
    
    public void RegisterObserver(IAffectionObserver observer){
        observers.Add(observer);
    }

    private void NotifyChangedAffection(){
        foreach (IAffectionObserver observer in observers){
            observer.OnAffectionChanged(affectionPoints);
        }
    }

    public void GameOver(){
        if(affectionPoints < 0){
            Debug.Log("Affection Points Below 0: Lock Shadow Out");
        } else {
            Debug.Log("You're okay for now");
        }
    }
}
