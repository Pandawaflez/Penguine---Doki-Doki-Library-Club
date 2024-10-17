using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//loop over creating objects while game is running, record when object doesn't get rendered; identify it
//relationship status overload ?
public class Stress
{
    // A Test behaves as an ordinary method
    [Test]
    [OneTimeSetUp]
    public void StressSimplePasses()
    {
        // Use the Assert class to test conditions

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator StressWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}