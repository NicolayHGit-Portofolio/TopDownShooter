using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected float speed;

    public GameObject holdingWeapon;

    protected void Movement(Vector2 movement)
    {
        rb.MovePosition(rb.position + (movement * speed * Time.deltaTime));
    }

    protected void Rotate(Vector2 direction)
    {
        Vector2 movement = direction - rb.position;
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    protected void UseWeapon()
    {
        Weapon weapon = holdingWeapon.GetComponent<Weapon>();
        if(weapon != null)
            weapon.AtemptoShot();
        
    }
}
