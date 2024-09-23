using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private string SavedScene;
    //save scene to load later (set Saved Scene)
    public void saveScene (){
        m_Scene = sceneManager.GetActiveScene();
        Debug.Log("Saving Scene " + m_Scene);
        SavedScene = m_Scene.name;
    }
    //load the scene that was just here:
    public string Continue () {
        Debug.Log("Loading Scene " + m_Scene);
        LoadScene(SavedScene);
    }
    public string getSavedScene(){
        return SavedScene;
    }
}
