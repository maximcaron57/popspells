using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SampleEditModeTest
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
}
