using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMove
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerMoveWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<PlayerMovement>();

            Assert.AreEqual(expected: new Vector2(x: 0, y: 0), actual: new Vector2(x: player.moveX, y: player.moveY * player.moveSpeed));

            yield return null;

  
        }
    }
}
