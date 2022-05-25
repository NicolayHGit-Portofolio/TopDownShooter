using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletObject bulletSetting;
    public float timeOut = 1f;

    public int damage = 25;

    public WeaponObject.weaponTypeList bulletType;

    [SerializeField]
    bool _enemyBullet = false;

    void Start()
    {
        timeOut = bulletSetting.timeOut;
        damage = bulletSetting.damage;
        bulletType = bulletSetting.bulletType;
        _enemyBullet = bulletSetting.enemyBullet;

        Invoke("DestroyBullet", timeOut);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Player" || tag == "Enemy")
        {
            Health target = collision.gameObject.GetComponent<Health>();
            if (target != null)
            {
                target.Damage(damage);
            }
        }
        if(tag == "Box")
        {
            LootBox loot = collision.gameObject.GetComponent<LootBox>();
            if (loot != null)
            {
                loot.DropLoot(true);
            }
        }
        if(tag == "Projectile")
        {
            Bullet collisionBullet = collision.gameObject.GetComponent<Bullet>();
            if (collisionBullet._enemyBullet != _enemyBullet)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

        if (tag != "Item" && tag != "Projectile")
        {
            Destroy(gameObject);
        }        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
