using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PlayerMove
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator FindPlayer()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            SceneManager.LoadScene("MainMenu");

            yield return new WaitForSeconds(3);

            
            var player = GameObject.FindGameObjectWithTag("Player");
       

            Assert.AreEqual("Player", player.tag);

            yield return new WaitForSeconds(3);

        }

        [UnityTest]
        public IEnumerator PlayerIsMoving()
        {
            SceneManager.LoadScene("MainMenu");
                
            yield return new WaitForSeconds(10);

            var gameObject = new GameObject("PlayerMoving");
            gameObject.AddComponent<PlayerMovement>();
            var player = gameObject.GetComponent<PlayerMovement>();
            bool moving;

           if ((player.moveX > 0.5f || player.moveX < -0.5f) == true || (player.moveY > 0.5f || player.moveY < -0.5f) != true)
            {
                moving = true;
            }
            else
            {
                moving = false;

            }

            Assert.AreEqual(true, moving);
        
        }
       /* public IEnumerator PlayerMoveWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var gameObject = new GameObject();
            var player = gameObject.AddComponent<PlayerMovement>();

            Assert.AreEqual(expected: new Vector2(x: 0, y: 0), actual: new Vector2(x: player.moveX, y: player.moveY * player.moveSpeed));

            yield return null;


        }*/
    }
}
