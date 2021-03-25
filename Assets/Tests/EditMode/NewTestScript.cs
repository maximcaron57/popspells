using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [Test]
    public void TestIncrement()
    {
        // Given
        var counter = 0;

        // When
        counter += 1;

        // Then
        Assert.AreEqual(1, counter);
    }
}
