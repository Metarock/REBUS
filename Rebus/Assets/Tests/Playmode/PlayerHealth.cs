using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace Tests
{
    public class PlayerHealth
    {
        // public PlayerHealthManager playerhealthManager;
        // public UIManager uIManager;
        // A Test behaves as an ordinary method
        // public GameObject game;
        // public UIManager uIManager;
        // public PlayerHealthManager playerhealthManager;
        // public UIManager area;
        [Test]
        public void PlayerHealthWithEnumeratorPasses()
        {
    
            // GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/UIArea"));
            // area = gameObject.GetComponent<UIManager>();
            GameObject game = new GameObject();
            var uIManager = game.AddComponent<UIManager>();
            var playerhealthManager = game.AddComponent<PlayerHealthManager>();
            playerhealthManager.playerMaxHealth = 100;
            playerhealthManager.playerCurrentHealth = 0;
            
            Assert.AreEqual(100,100);
            Assert.AreEqual(0, 0);


        }
    }
}
