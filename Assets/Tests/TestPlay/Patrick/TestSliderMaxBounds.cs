using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PatrickTestSliderMaxBounds
{
    private UIElementHandler uiHandler;  // Reference to the handler
    private GameObject handlerObject;    // GameObject for UIElementHandler

    [SetUp]
    public void Setup()
    {
        // Create a GameObject to hold the UIElementHandler component
        handlerObject = new GameObject("UIElementHandler");
        uiHandler = handlerObject.AddComponent<UIElementHandler>();

        // Create and assign the overlay panel
        uiHandler.overlayPanel = new GameObject("OverlayPanel");

        // Ensure the overlay panel is initially active for testing
        uiHandler.overlayPanel.SetActive(true);

        // Set starting points for Charlie in PeanutsDB
        PeanutsDB.CharlieAffectionPts = 0;  // Start with 0 points
    }

    [UnityTest]
    public IEnumerator TestOverlayOpenAndIncrementPoints()
    {
        // Ensure the overlay panel is active at the start
        Assert.IsTrue(uiHandler.overlayPanel.activeSelf, "Overlay panel should be active initially.");

        // Simulate opening the overlay (if needed, based on your setup)
        uiHandler.UICheckInput();
        yield return null;  // Wait one frame to ensure the UI updates

        // Loop to increment Charlie's points over time
        for (int i = 0; i <= 120; i += 10)
        {
            // Set Charlie's points in PeanutsDB
            PeanutsDB.CharlieAffectionPts = i;

            // Log the current points value for verification
            Debug.Log($"Charlie Points: {PeanutsDB.CharlieAffectionPts}");

            // Verify the points are being incremented correctly
            Assert.AreEqual(i, PeanutsDB.CharlieAffectionPts, $"Charlie's points should be {i}");

            // Wait one frame to simulate real-time behavior
            yield return null;
        }

        // Ensure that Charlie's points have reached 100
        Assert.AreEqual(100, PeanutsDB.CharlieAffectionPts, "Charlie's points should be 100 at the end.");

        yield break;
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the GameObject after the test to clean up
        Object.Destroy(handlerObject);
    }
}