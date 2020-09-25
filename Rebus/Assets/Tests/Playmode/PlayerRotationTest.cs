using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerRotationTest
    {
        [Test]
        public void TestRotation()
        {

            // Assign
            var gameObject = new GameObject("Rotation");
            gameObject.AddComponent<RotateScript>();
            Vector3 mousePos = new Vector3(1,1,1);
            gameObject.GetComponent<RotateScript>().mousePos = mousePos;

            // Act
            gameObject.GetComponent<RotateScript>().cursorDirection();


            // Assert : Testing if the "transform.up" is equal to the "direction"
            Assert.AreEqual(expected: gameObject.GetComponent<RotateScript>().direction, actual: gameObject.GetComponent<RotateScript>().transform.up);

        }
    }
}
