using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTest
    {
        [Test]
        public void TestShootingAI()
        {
            //Assign


            var gameObject = new GameObject();
            gameObject.AddComponent<Enemy>();
            Enemy enemy = gameObject.GetComponent<Enemy>();
            bool statementHolds = false;
            
            enemy.GetComponent<Enemy>().target.transform.position = new Vector3(5, 5, 10);
            enemy.GetComponent<Enemy>().transform.position = new Vector3(5, 5, 2);

            //RESULT VECTOR:  Vector3 correctVector = new Vector3(0, 0, 8);

            Quaternion correctRotation = new Quaternion(-90, 0, 0, 1);



            //Act
            enemy.ShootingAI();

            //if(enemy.GetComponent<Enemy>().)
            

            /*enemy.isExploded = false;
            enemy.dirX = 1f;
            enemy.dirY = 2f;


            enemy.FixedUpdate();

            Assert.AreEqual(expected true, actual )*/


        }
    }
}
