using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SwitchingWeapon
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator WeaponSwitching_LAST_PLAYER_POSITION()
        {

            // Use the Assert class to test conditions
            SceneManager.LoadScene("MainMenu");

            yield return new WaitForSeconds(10);
            var gameObject = new GameObject("weaponswitching");
            gameObject.AddComponent<WeaponSwitching>();
            var switching = gameObject.GetComponent<WeaponSwitching>();

            
            //making sure the player position is set, under SelectedWeapon
            switching.lastPosX = PlayerMovement.lastPosX;
            switching.lastPosY = PlayerMovement.lastPosY;
            Assert.AreEqual(new Vector2(PlayerMovement.lastPosX, PlayerMovement.lastPosY), new Vector2(switching.lastPosX, switching.lastPosY));
        }
    }
}
