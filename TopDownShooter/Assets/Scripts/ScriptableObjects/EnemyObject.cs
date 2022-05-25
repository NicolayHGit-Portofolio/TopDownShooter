using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Objects/New Enemy")]
public class EnemyObject : ScriptableObject
{
    public GameObject holdingWeapon;
    public int health;
    public float speed;
    public float minDist;
}
