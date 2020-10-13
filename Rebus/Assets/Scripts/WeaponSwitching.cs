using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    public GameObject selectedPlayer;

    private PlayerMovement playerMovement;

    public float lastPosX;
    public float lastPosY;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();

        lastPosX = 0;
        lastPosY = 0;
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
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        // Number Keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;

        // This basically shows how it loops until it matches with the selected weapon.
        foreach (Transform weapon in transform)
        {
            // Sets the selected weapon as active/inactive
            if ( i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);

                selectedPlayer = GameObject.Find(weapon.gameObject.name);

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
