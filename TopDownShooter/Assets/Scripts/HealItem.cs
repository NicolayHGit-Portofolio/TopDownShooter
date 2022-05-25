using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health healing = collision.gameObject.GetComponent<Health>();
            healing.Heal(100);
            Destroy(gameObject);
        }
    }
}
