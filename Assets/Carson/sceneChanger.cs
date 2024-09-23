using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class sceneChanger : MonoBehaviour
{
    private string SavedScene;
    //save scene to load later (set Saved Scene)
    public static void saveScene (){
        m_Scene = SceneManager.GetActiveScene();
        Debug.Log("Saving Scene " + m_Scene);
        SavedScene = m_Scene.name;
    }
    //load the scene that was just here:
    public static string Continue () {
        Debug.Log("Loading Scene " + m_Scene);
        SceneManager.LoadScene(SavedScene);
    }
    //return the saved scene, probably will be just used for testing shrug
    public string getSavedScene(){
        return SavedScene;
    }
}
