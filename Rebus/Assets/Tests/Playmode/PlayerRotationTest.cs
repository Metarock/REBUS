using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerRotationTest
    {
        [Test]
        public void TestIncrement()
        {
            // Assign
            var gameObject = new GameObject();
            RotateScript counter = gameObject.GetComponent<RotateScript>();

            // Act
            counter.cursorDirection();

            // Assert
            Assert.AreEqual(expected: counter.direction, actual: counter.transform.up);
        }
    }
}
