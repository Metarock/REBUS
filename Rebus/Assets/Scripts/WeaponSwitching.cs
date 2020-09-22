using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary Variable
        int previousSelectedWeapon = selectedWeapon;

        // Before numbers, we can use the mouse scroll wheel to access the weapons
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            // Prevents the counter to run infinitely
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            // Prevents the counter to run infinitely
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;
        // This basically shows how it loops until i matches with the selected weapon.
        foreach (Transform weapon in transform)
        {
            // Sets the selected weapon as active/inactive
            if ( i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
