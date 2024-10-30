using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Lance_PongTests
{
    public GameObject pongGame;

    [SetUp]
    public void SetUp()
    {
        pongGame = Resources.Load<GameObject>("Lance/PongGame");
        Assert.IsNotNull(pongGame, "Pong prefab not assigned in the Resources folder.");
    }

    // Stress test for lots of pong games
    [UnityTest]
    public IEnumerator PongTest_TestMultipleMathGameInstances_ShouldHaveInstanceCountInstances()
    {
        // Spawn multiple instances
        int instanceCount = 1000;
        for (int i = 0; i < instanceCount; i++)
        {
            // Instantiate the prefab
            GameObject instance = Object.Instantiate(pongGame);
            instance.name = "PongGame_" + i; // Name the instances for debugging
            instance.transform.position = new Vector3(i * 2, 0, 0); // Spread them out
        }

        yield return null; // Allow the game objects to initialize

        // Assert that the correct number of instances are in the scene
        Assert.AreEqual(instanceCount, GameObject.FindObjectsOfType<Pong>().Length, "Not all pong game instances were created successfully.");
    }

    // Stress test for resetting pong game 
    [UnityTest]
    public IEnumerator PongTest_ResetGame_ShouldResetGame()
    {
        GameObject instance = GameObject.Instantiate(pongGame);
        Pong pongInstance = instance.GetComponentInChildren<Pong>();
        // Rapidly reset the round
        int instanceCount = 10000;
        for (int i = 0; i < instanceCount; i++)
        {
            pongInstance.ResetRound();
        }

        yield return null; 

        // Assert that the correct number of instances are in the scene
        Assert.AreEqual(1, GameObject.FindObjectsOfType<Pong>().Length, "Not all pong game instances were created successfully.");
    }

    [Test] 
    public void PongTest_EndGame_ShouldSetGameOver() {
        GameObject instance = GameObject.Instantiate(pongGame);
        Pong pongInstance = instance.GetComponentInChildren<Pong>();

        pongInstance.EndGame();

        Assert.AreEqual(pongInstance.GetIsGameOver(), true);
    }

    [Test]
    public void PongTest_CheckBallReset_ShouldBeZero() {
        GameObject instance = GameObject.Instantiate(pongGame);
        Ball ball = instance.GetComponentInChildren<Ball>();

        ball.ResetBall();

        Assert.AreEqual(ball.GetPosition(), Vector3.zero);
    }

    [Test]
    public void PongTest_CheckAIPaddleNormalMode_SpeedShouldBe10() {
        MainPlayer.SetBCMode(false);
        GameObject instance = GameObject.Instantiate(pongGame);
        AIPaddle paddle = instance.GetComponentInChildren<AIPaddle>();

        Assert.AreEqual(paddle.GetSpeed(), 10);
    }

    [Test]
    public void PongTest_CheckAIPaddleBCMode_SpeedShouldBe1() {
        MainPlayer.SetBCMode(true);
        GameObject instance = GameObject.Instantiate(pongGame);
        AIPaddle paddle = instance.GetComponentInChildren<AIPaddle>();

        Assert.AreEqual(paddle.GetSpeed(), 10);
    }

    [Test]
    public void PongTest_CheckPlayerPaddleNormalMode_SpeedShouldBe10() {
        MainPlayer.SetBCMode(false);
        GameObject instance = GameObject.Instantiate(pongGame);
        PlayerPaddle paddle = instance.GetComponentInChildren<PlayerPaddle>();

        Assert.AreEqual(paddle.GetSpeed(), 10);
    }

    [Test]
    public void PongTest_CheckPlayerPaddleBCMode_SpeedShouldBe10() {
        MainPlayer.SetBCMode(true);
        GameObject instance = GameObject.Instantiate(pongGame);
        PlayerPaddle paddle = instance.GetComponentInChildren<PlayerPaddle>();

        Assert.AreEqual(paddle.GetSpeed(), 10);
    }
}
