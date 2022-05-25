using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{

    [SerializeField]
    WeaponObject.weaponTypeList _weaponType;

    GameObject _weaponHolder;

    int randomIndex;

    void Start()
    {
        randomIndex = Random.Range(0, 4);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WeaponSwitching.ws.GetAmmo(randomIndex);
            Destroy(gameObject);
        }
    }
}
