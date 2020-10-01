using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class EnemyTest
    {
        [UnityTest]
        public IEnumerator EnemyShootingTest()
        {
            SceneManager.LoadScene("MainMenu");
            yield return new WaitForSeconds(10);

            //Assign
            var gameObject = new GameObject("enemy");
            gameObject.AddComponent<Enemy>();
            gameObject.AddComponent<Animator>();
            gameObject.AddComponent<Rigidbody2D>();
            //gameObject.AddComponent<BoxCollider2D>();
            Enemy enemy = gameObject.GetComponent<Enemy>();
            
            enemy.GetComponent<Enemy>().target.transform.position = new Vector3(5, 5, 10);
            enemy.GetComponent<Enemy>().transform.position = new Vector3(5, 5, 2);

            //RESULT VECTOR:  Vector3 correctVector = new Vector3(0, 0, 8);

            Quaternion correctRotation = new Quaternion(-90, 0, 0, 1);

            //Act
            enemy.ShootingAI();

            //Assert
            Assert.AreEqual(correctRotation, enemy.GetComponent<Enemy>().transform.rotation);
        }
    }
}
