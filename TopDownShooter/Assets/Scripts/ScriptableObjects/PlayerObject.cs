using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerAttributes", menuName = "Objects/New Player")]
public class PlayerObject : ScriptableObject
{
    public GameObject holdingWeapon;
    public int health;
    public float speed;
}
