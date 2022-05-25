using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    int weaponSelected = 0;

    public static WeaponSwitching ws;

    // Start is called before the first frame update
    void Start()
    {
        weaponSelected = 0;
        if (ws == null)
            ws = gameObject.GetComponent<WeaponSwitching>();

        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = weaponSelected;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSelected >= transform.childCount - 1)
                weaponSelected = 0;
            else
                weaponSelected++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSelected <= 0)
                weaponSelected = transform.childCount - 1;
            else
                weaponSelected--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSelected = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            weaponSelected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            weaponSelected = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            weaponSelected = 3;
        }

        if (previousWeapon != weaponSelected)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSelected)
            {
                weapon.gameObject.SetActive(true);
                GameObject pc = GameObject.FindGameObjectWithTag("Player");
                Player player = pc.GetComponent<Player>();
                player.holdingWeapon = weapon.gameObject;
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        
    }

    public void GetAmmo(int weaponIndex)
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponIndex)
            {
                Weapon weaponAmmo = weapon.gameObject.GetComponent<Weapon>();
                if (weaponAmmo != null)
                {
                    weaponAmmo._ammo += 20;
                    weaponAmmo.UpdateAmmoText();
                }
            }
            i++;
        }
    }
}
