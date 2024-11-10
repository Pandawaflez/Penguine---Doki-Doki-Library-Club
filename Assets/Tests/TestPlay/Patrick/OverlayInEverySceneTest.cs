using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


//test each scene in our game to ensure the overlay properly opens
public class Patrick_OverlayWorkingTests
{
     private bool sceneLoaded;
    [OneTimeSetUp]
    public void OneTimeSetUp() 
    //public void SetUp()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Menu", LoadSceneMode.Single);

        MainPlayer.SetPlayerName("playerName");
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg) 
    {
        sceneLoaded = true;
    }

    //overlay shouldn't open in menu
    [UnityTest]
    public IEnumerator A_MenuScene()
    {
        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsFalse(UIElementHandler.UIGod.isOpen(), "overlay should not be open");

        yield return null;
    }

    //overlay should open in Overworld
    [UnityTest]
    public IEnumerator B_OverworldScene()
    {
        SceneManager.LoadScene("Scenes/Overworld", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Level1
    [UnityTest]
    public IEnumerator C_CharlieScene()
    {
        SceneManager.LoadScene("Scenes/Level1", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }


    //overlay should open in Lucy scene
    [UnityTest]
    public IEnumerator D_LucyScene()
    {
        SceneManager.LoadScene("Scenes/Lucy", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Snoopy scene
    [UnityTest]
    public IEnumerator E_SnoopyScene()
    {
        SceneManager.LoadScene("Scenes/Snoopy", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Schroeder scene
    [UnityTest]
    public IEnumerator F_SchroederScene()
    {
        SceneManager.LoadScene("Scenes/Schroeder", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Sonic scene
    [UnityTest]
    public IEnumerator G_SonicScene()
    {
        SceneManager.LoadScene("Scenes/Sonic", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Shadow scene
    [UnityTest]
    public IEnumerator H_ShadowScene()
    {
        SceneManager.LoadScene("Scenes/Shadow", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Shaggy scene
    [UnityTest]
    public IEnumerator I_ShaggyScene()
    {
        SceneManager.LoadScene("Scenes/Shaggy", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Daphne scene
    [UnityTest]
    public IEnumerator J_DaphneScene()
    {
        SceneManager.LoadScene("Scenes/Daphne", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Fred scene
    [UnityTest]
    public IEnumerator K_FredScene()
    {
        SceneManager.LoadScene("Scenes/Fred", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //now test overlay comes up in the minigame scenes too
    //overlay should open in Math scene
    [UnityTest]
    public IEnumerator L_mathScene()
    {
        SceneManager.LoadScene("Scenes/Math", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Pong scene
    [UnityTest]
    public IEnumerator M_PongScene()
    {
        SceneManager.LoadScene("Scenes/Pong", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }

    //overlay should open in Minesweeper scene
    [UnityTest]
    public IEnumerator N_MineSweeperScene()
    {
        SceneManager.LoadScene("Scenes/Minesweeper", LoadSceneMode.Single);

        yield return null;

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;

        Assert.IsTrue(UIElementHandler.UIGod.isOpen(), "overlay should be open");

        UIElementHandler.UIGod.ShowOverlayTest();

        yield return null;
    }
}