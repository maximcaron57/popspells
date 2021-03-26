using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
    public class SamplePlayModeTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            var counter = 0;

            counter += 1;

            Assert.AreEqual(1, counter);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Given
            var counter = 3;

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            // When
            counter += 1;

            // Then
            Assert.AreEqual(4, counter);
        }
    }
}
