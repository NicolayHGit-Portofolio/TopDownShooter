using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponAttributes", menuName = "Objects/New Weapon")]
public class WeaponObject : ScriptableObject
{
    public enum weaponTypeList { Pistol, Shotgun, Machinegun, Sniper };

    public weaponTypeList weaponType;

    public GameObject bulletPrefab;
    public float bulletForce;
    public float fireRate;
    public int bulletDamage;
    public int ammo;
}
