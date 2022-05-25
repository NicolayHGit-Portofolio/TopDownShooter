using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletAttributes", menuName = "Objects/New Bullet")]
public class BulletObject : ScriptableObject
{
    public float timeOut;
    public int damage;
    public bool enemyBullet = false;
    public WeaponObject.weaponTypeList bulletType;
}
